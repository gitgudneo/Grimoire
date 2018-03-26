package grimoire
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.system.Security;
	import flash.display.Loader;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.net.URLVariables;
	import flash.events.ProgressEvent;
	import flash.external.ExternalInterface;
	import flash.utils.ByteArray;
	import flash.events.MouseEvent;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import grimoire.tools.SFSEvent;
	import grimoire.tools.Base64;
	import grimoire.game.Player;
	import grimoire.game.World;
	import grimoire.game.Quests;
	import grimoire.game.Shops;
	import grimoire.game.Bank;
	import grimoire.game.Inventory;
	import grimoire.game.TempInventory;
	import grimoire.game.AutoRelogin;
	import grimoire.game.Settings;

	public class Root extends MovieClip
	{
		private var sFile:String;
		private var urlLoader:URLLoader;
		private var loader:Loader;
		private var loaderVars:Object;
		private const sTitle:String = "Grimoire";
		private const sURL:String = "https://www.aq.com/game/";
		private const versionURL:String = "https://www.aq.com/game/gameversion.asp";
		public static var Game:Object;
		private var stg:*;

		public static const TrueString:String = "\"True\"";
		public static const FalseString:String = "\"False\"";

		public static var Username:String;
		public static var Password:String;

		public function Root()
		{
			addEventListener(Event.ADDED_TO_STAGE, OnAddedToStage);
		}

		private function OnAddedToStage(e:Event):void
		{
			removeEventListener(Event.ADDED_TO_STAGE, OnAddedToStage);
			Security.allowDomain("*");
			urlLoader = new URLLoader();
			urlLoader.addEventListener(Event.COMPLETE, OnDataComplete);
			urlLoader.load(new URLRequest(versionURL));
		}

		private function OnDataComplete(e:Event):void
		{
			urlLoader.removeEventListener(Event.COMPLETE, OnDataComplete);

			var vars:URLVariables = new URLVariables(e.target.data);

			if (vars.status == "success")
			{
				sFile = vars.sFile;
				loaderVars = vars;
				LoadGame();
			}
		}

		private function LoadGame():void
		{
			loader = new Loader();
			loader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS, OnProgress);
			loader.contentLoaderInfo.addEventListener(Event.COMPLETE, OnComplete);
			loader.load(new URLRequest(sURL + "gamefiles/" + sFile));
		}

		private function OnProgress(e:ProgressEvent):void
		{
			ExternalInterface.call("progress", Math.round(Number(e.currentTarget.bytesLoaded / e.currentTarget.bytesTotal) * 100));
		}

		private function OnComplete(e:Event):void
		{
			loader.contentLoaderInfo.removeEventListener(ProgressEvent.PROGRESS, OnProgress);
			loader.contentLoaderInfo.removeEventListener(Event.COMPLETE, OnComplete);

			stg = stage;
			stg.removeChildAt(0);

			Game = stg.addChild(MovieClip(Loader(e.target.loader).content));
			
			var param:*;
			for (param in root.loaderInfo.parameters)
			{
				Game.params[param] = root.loaderInfo.parameters[param];
			}

			Game.params.sURL = sURL;
			Game.params.sTitle = sTitle;
			Game.params.vars = loaderVars;
			
			Game.sfc.addEventListener(SFSEvent.onConnectionLost, OnDisconnect);
			Game.loginLoader.addEventListener(Event.COMPLETE, OnLoginComplete);
			addEventListener(Event.ENTER_FRAME, EnterFrame);
			Externalize();
		}
		
		private function OnDisconnect(e:*):void
		{
			ExternalInterface.call("disconnect");
		}
		
		private function OnLoginComplete(e:Event):void
		{
			e.target.data = String(ExternalInterface.call("modifyServers", e.target.data));
		}

		private function EnterFrame(e:Event):void
		{
			if (Game.mcLogin != null && Game.mcLogin.ni != null && Game.mcLogin.pi != null && Game.mcLogin.btnLogin != null)
			{
				removeEventListener(Event.ENTER_FRAME, EnterFrame);
				var btn:* = Game.mcLogin.btnLogin;
				btn.addEventListener(MouseEvent.CLICK, OnLoginClick);
			}
		}

		private function OnLoginClick(e:MouseEvent):void
		{
			var btn:* = Game.mcLogin.btnLogin;
			btn.removeEventListener(MouseEvent.CLICK, OnLoginClick);
			Username = Game.mcLogin.ni.text;
			Password = Game.mcLogin.pi.text;
		}

		private function Externalize():void
		{
			// <Player>
			ExternalInterface.addCallback("IsLoggedIn", Player.IsLoggedIn);
			ExternalInterface.addCallback("Cell", Player.Cell);
			ExternalInterface.addCallback("Pad", Player.Pad);
			ExternalInterface.addCallback("State", Player.State);
			ExternalInterface.addCallback("Health", Player.Health);
			ExternalInterface.addCallback("HealthMax", Player.HealthMax);
			ExternalInterface.addCallback("Mana", Player.Mana);
			ExternalInterface.addCallback("ManaMax", Player.ManaMax);
			ExternalInterface.addCallback("Map", Player.Map);
			ExternalInterface.addCallback("Level", Player.Level);
			ExternalInterface.addCallback("Gold", Player.Gold);
			ExternalInterface.addCallback("HasTarget", Player.HasTarget);
			ExternalInterface.addCallback("IsAfk", Player.IsAfk);
			ExternalInterface.addCallback("AllSkillsAvailable", Player.AllSkillsAvailable);
			ExternalInterface.addCallback("Position", Player.Position);
			ExternalInterface.addCallback("WalkToPoint", Player.WalkToPoint);
			ExternalInterface.addCallback("CancelTarget", Player.CancelTarget);
			ExternalInterface.addCallback("AttackMonster", Player.AttackMonster);
			ExternalInterface.addCallback("Jump", Player.Jump);
			ExternalInterface.addCallback("Rest", Player.Rest);
			ExternalInterface.addCallback("Join", Player.Join);
			ExternalInterface.addCallback("Equip", Player.Equip);
			ExternalInterface.addCallback("GoTo", Player.GoTo);
			ExternalInterface.addCallback("UseBoost", Player.UseBoost);
			ExternalInterface.addCallback("UseSkill", Player.UseSkill);
			ExternalInterface.addCallback("GetMapItem", Player.GetMapItem);
			ExternalInterface.addCallback("Logout", Player.Logout);
			ExternalInterface.addCallback("HasActiveBoost", Player.HasActiveBoost);
			// </Player>

			// <World>
			ExternalInterface.addCallback("MapLoadComplete", World.MapLoadComplete);
			ExternalInterface.addCallback("PlayersInMap", World.PlayersInMap);
			ExternalInterface.addCallback("IsActionAvailable", World.IsActionAvailable);
			ExternalInterface.addCallback("GetMonstersInCell", World.GetMonstersInCell);
			ExternalInterface.addCallback("GetVisibleMonstersInCell", World.GetVisibleMonstersInCell);
			ExternalInterface.addCallback("SetSpawnPoint", World.SetSpawnPoint);
			ExternalInterface.addCallback("IsMonsterAvailable", World.IsMonsterAvailable);
			ExternalInterface.addCallback("GetSkillName", World.GetSkillName);
			ExternalInterface.addCallback("GetCells", World.GetCells);
			ExternalInterface.addCallback("GetItemTree", World.GetItemTree);
			ExternalInterface.addCallback("RoomId", World.RoomId);
			// </World>

			// <Quests>
			ExternalInterface.addCallback("IsInProgress", Quests.IsInProgress);
			ExternalInterface.addCallback("Complete", Quests.Complete);
			ExternalInterface.addCallback("Accept", Quests.Accept);
			ExternalInterface.addCallback("LoadQuest", Quests.Load);
			ExternalInterface.addCallback("LoadQuests", Quests.LoadMultiple);
			ExternalInterface.addCallback("GetQuests", Quests.GetQuests);
			ExternalInterface.addCallback("GetQuestTree", Quests.GetQuestTree);
			ExternalInterface.addCallback("CanComplete", Quests.CanComplete);
			// </Quests>

			// <Shops>
			ExternalInterface.addCallback("GetShops", Shops.GetShops);
			ExternalInterface.addCallback("LoadShop", Shops.Load);
			ExternalInterface.addCallback("LoadHairShop", Shops.LoadHairShop);
			ExternalInterface.addCallback("LoadArmorCustomizer", Shops.LoadArmorCustomizer);
			ExternalInterface.addCallback("SellItem", Shops.SellItem);
			ExternalInterface.addCallback("ResetShopInfo", Shops.ResetShopInfo);
			ExternalInterface.addCallback("IsShopLoaded", Shops.IsShopLoaded);
			ExternalInterface.addCallback("BuyItem", Shops.BuyItem);
			// </Shops>

			// <Bank>
			ExternalInterface.addCallback("GetBankItems", Bank.GetBankItems);
			ExternalInterface.addCallback("BankSlots", Bank.BankSlots);
			ExternalInterface.addCallback("UsedSlots", Bank.UsedSlots);
			ExternalInterface.addCallback("TransferToBank", Bank.TransferToBank);
			ExternalInterface.addCallback("TransferToInventory", Bank.TransferToInventory);
			ExternalInterface.addCallback("BankSwap", Bank.BankSwap);
			ExternalInterface.addCallback("ShowBank", Bank.Show);
			ExternalInterface.addCallback("LoadBankItems", Bank.LoadBankItems);
			// </Bank>

			// <Inventory>
			ExternalInterface.addCallback("GetInventoryItems", Inventory.GetInventoryItems);
			ExternalInterface.addCallback("InventorySlots", Inventory.InventorySlots);
			ExternalInterface.addCallback("UsedInventorySlots", Inventory.UsedInventorySlots);
			// </Inventory>

			// <TempInventory>
			ExternalInterface.addCallback("GetTempItems", TempInventory.GetTempItems);
			ExternalInterface.addCallback("ItemIsInTemp", TempInventory.ItemIsInTemp);
			// </TempInventory>

			// <AutoRelogin>
			ExternalInterface.addCallback("IsTemporarilyKicked", AutoRelogin.IsTemporarilyKicked);
			ExternalInterface.addCallback("Login", AutoRelogin.Login);
			ExternalInterface.addCallback("ResetServers", AutoRelogin.ResetServers);
			ExternalInterface.addCallback("AreServersLoaded", AutoRelogin.AreServersLoaded);
			ExternalInterface.addCallback("Connect", AutoRelogin.Connect);
			// </AutoRelogin>

			// <Rest>
			ExternalInterface.addCallback("GetUsername", GetUsername);
			ExternalInterface.addCallback("GetPassword", GetPassword);
			ExternalInterface.addCallback("SetFPS", SetFPS);
			ExternalInterface.addCallback("RealAddress", RealAddress);
			// </Rest>

			// <Settings>
			ExternalInterface.addCallback("SetInfiniteRange", Settings.SetInfiniteRange);
			ExternalInterface.addCallback("SetProvokeMonsters", Settings.SetProvokeMonsters);
			ExternalInterface.addCallback("SetEnemyMagnet", Settings.SetEnemyMagnet);
			ExternalInterface.addCallback("SetLagKiller", Settings.SetLagKiller);
			ExternalInterface.addCallback("DestroyPlayers", Settings.DestroyPlayers);
			ExternalInterface.addCallback("SetSkipCutscenes", Settings.SetSkipCutscenes);
			ExternalInterface.addCallback("SetWalkSpeed", Settings.SetWalkSpeed);
			// </Settings>
		}

		public function RealAddress():String
		{
			return "\"" + Game.objServerInfo.RealAddress + "\"";
		}

		private function GetUsername():String
		{
			return "\"" + Username + "\"";
		}

		private function GetPassword():String
		{
			return "\"" + Password + "\"";
		}

		private function SetFPS(fps:String):void
		{
			stg.frameRate = parseInt(fps);
		}
	}
}
