package grimoire.game
{
	import grimoire.Root;
	import flash.utils.ByteArray;
	
	public class Quests 
	{
		public function Quests() 
		{
			
		}
		
		public static function IsInProgress(id:String):String
		{
			return Root.Game.world.isQuestInProgress(parseInt(id)) ? Root.TrueString : Root.FalseString;
		}
		
		public static function Complete(id:String, itemID:String = "-1", special:String = "False"):void
		{
			Root.Game.world.tryQuestComplete(parseInt(id), parseInt(itemID), special == "True");
		}
		
		public static function Accept(id:String):void
		{
			Root.Game.world.acceptQuest(parseInt(id));
		}
		
		public static function Load(id:String):void
		{
			Root.Game.world.showQuests([id], "q");
		}
		
		public static function LoadMultiple(ids:String):void
		{
			Root.Game.world.showQuests(ids.split(","), "q");
		}
		
		public static function GetQuests(ids:String):void
		{
			Root.Game.world.getQuests(ids.split(","));
		}
		
		public static function CanComplete(id:String):String
		{
			return Root.Game.world.canTurnInQuest(parseInt(id)) ? Root.TrueString : Root.FalseString;
		}
		
		private static function CloneObject(source:Object):Object
		{ 
			var ba:ByteArray = new ByteArray(); 
			ba.writeObject(source); 
			ba.position = 0; 
			return ba.readObject(); 
		}
		
		public static function GetQuestTree():String
		{
			var quests:Array = [];
			for each (var q:Object in Root.Game.world.questTree)
			{
				var quest:Object = CloneObject(q);
				trace("quest: " + quest);
				var requirements:Array = [];
				var rewards:Array = [];
				
				if (q.turnin != null && q.oItems != null)
				{
					for each (var req:Object in q.turnin)
					{
						var _req:Object = new Object();
						var item = q.oItems[req.ItemID];
						_req.sName = item.sName;
						_req.ItemID = item.ItemID;
						_req.iQty = req.iQty;
						requirements.push(_req);
					}
				}
				
				quest.RequiredItems = requirements;
				
				if (q.reward != null && q.oRewards != null)
				{
					for each (var rew:Object in q.reward)
					{
						for each (var rewContainer:* in q.oRewards)
						{
							for each (var _item:Object in rewContainer)
							{
								if (_item.ItemID != null && _item.ItemID == rew.ItemID)
								{
									var reward:Object = new Object();
									reward.sName = _item.sName;
									reward.ItemID = rew.ItemID;
									reward.iQty = rew.iQty;
									reward.DropChance = String(rew.iRate) + "%";
									rewards.push(reward);
								}
							}
						}
					}
				}
				
				quest.Rewards = rewards;
				quests.push(quest);
			}
			return JSON.stringify(quests);
		}
	}
}
