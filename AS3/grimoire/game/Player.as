package grimoire.game
{
	import grimoire.Root;
	import grimoire.game.Inventory;
	import flash.events.MouseEvent;
	public class Player 
	{
		public static function IsLoggedIn():String
		{
			return (Root.Game != null && Root.Game.sfc != null && Root.Game.sfc.isConnected == true) ? Root.TrueString : Root.FalseString;
		}
		
		public static function Cell():String
		{
			return "\"" + Root.Game.world.strFrame + "\"";
		}
		
		public static function Pad():String
		{
			return "\"" + Root.Game.world.strPad + "\"";
		}
		
		public static function State():int
		{
			return Root.Game.world.myAvatar.dataLeaf.intState;
		}
		
		public static function Health():int
		{
			return Root.Game.world.myAvatar.dataLeaf.intHP;
		}
		
		public static function HealthMax():int
		{
			return Root.Game.world.myAvatar.dataLeaf.intHPMax;
		}
		
		public static function Mana():int
		{
			return Root.Game.world.myAvatar.dataLeaf.intMP;
		}
		
		public static function ManaMax():int
		{
			return Root.Game.world.myAvatar.dataLeaf.intMPMax;
		}
		
		public static function Map():String
		{
			return "\"" + Root.Game.world.strMapName + "\"";
		}
		
		public static function Level():int
		{
			return Root.Game.world.myAvatar.dataLeaf.intLevel;
		}
		
		public static function Gold():int
		{
			return Root.Game.world.myAvatar.objData.intGold;
		}
		
		public static function HasTarget():String
		{
			return (Root.Game.world.myAvatar.target != null && Root.Game.world.myAvatar.target.dataLeaf.intHP > 0) ? Root.TrueString : Root.FalseString;
		}
		
		public static function IsAfk():String
		{
			return (Root.Game.world.myAvatar.dataLeaf.afk) ? Root.TrueString : Root.FalseString;
		}
		
		public static function AllSkillsAvailable():String
		{
			return (actionTimeCheck(Root.Game.world.actions.active[1]) &&
				   actionTimeCheck(Root.Game.world.actions.active[2]) &&
			       actionTimeCheck(Root.Game.world.actions.active[3]) &&
				   actionTimeCheck(Root.Game.world.actions.active[4])) ? Root.TrueString : Root.FalseString;
		}
		
		private static function actionTimeCheck(param1) : Boolean
        {
            var _loc_4:* = 0;
            var _loc_2:* = new Date().getTime();
            var _loc_3:* = 1 - Math.min(Math.max(Root.Game.world.myAvatar.dataLeaf.sta.$tha, -1), 0.5);
            if (param1.auto)
            {
                if (Root.Game.world.autoActionTimer.running)
                {
                    trace("AA TIMER SELF-CLIPPING");
                    return false;
                }
                return true;
            }
            if (_loc_2 - Root.Game.world.GCDTS < Root.Game.world.GCD)
            {
                return false;
            }
            if (param1.OldCD != null)
            {
                _loc_4 = Math.round(param1.OldCD * _loc_3);
            }
            else
            {
                _loc_4 = Math.round(param1.cd * _loc_3);
            }

            if (_loc_2 - param1.ts >= _loc_4)
            {
                delete param1.OldCD;
                return true;
            }
            return false;
        }
		
		public static function Position():String
		{
			return JSON.stringify([Root.Game.world.myAvatar.pMC.x, Root.Game.world.myAvatar.pMC.y]);
		}
		
		public static function WalkToPoint(strX:String, strY:String):void
		{
			var x:int = parseInt(strX);
			var y:int = parseInt(strY);
			
			Root.Game.world.myAvatar.pMC.walkTo(x, y, Root.Game.world.WALKSPEED);
			Root.Game.world.moveRequest({mc:Root.Game.world.myAvatar.pMC, tx:x, ty:y, sp:Root.Game.world.WALKSPEED});
		}
		
		public static function CancelTarget():void
		{
			if (Root.Game.world.myAvatar.target != null)
				Root.Game.world.cancelTarget();
		}
		
		public static function AttackMonster(name:String):void
		{
			var monster:Object = World.GetMonsterByName(name);
			
			if (monster != null)
			{
				try
				{
					Root.Game.world.setTarget(monster);
					Root.Game.world.approachTarget();
				}
				catch (e:*)
				{
					return;
				}
			}
		}
		
		public static function Jump(cell:String, pad:String = "Spawn"):void
		{
			Root.Game.world.moveToCell(cell, pad);
		}
		
		public static function Rest():void
		{
			Root.Game.world.rest();
		}
		
		public static function Join(map:String, cell:String = "Enter", pad:String = "Spawn"):void
		{
			Root.Game.world.gotoTown(map, cell, pad);
		}
		
		public static function Equip(itemID:String):void
		{
			Root.Game.world.sendEquipItemRequest({ItemID:parseInt(itemID)});
		}
		
		public static function GoTo(player:String):void
		{
			Root.Game.world.goto(player);
		}
		
		public static function UseBoost(id:String):void
		{
			var boost:Object = Inventory.GetItemByID(parseInt(id));
			if (boost != null)
				Root.Game.world.sendUseItemRequest(boost);
		}
		
		public static function UseSkill(index:String):void
		{
			if (Root.Game.world.myAvatar.target == Root.Game.world.myAvatar)
			{
				Root.Game.world.myAvatar.target = null;
				return;
			}
			
			var skill:Object = Root.Game.world.actions.active[parseInt(index)];
			
			if (Root.Game.world.myAvatar.target != null && Root.Game.world.myAvatar.target.dataLeaf.intHP > 0)
			{
				Root.Game.world.approachTarget();
				if (actionTimeCheck(skill))
				{
					if (Root.Game.world.myAvatar.dataLeaf.intMP >= skill.mp)
					{
						if (skill.isOK && !skill.lock)
						{
							Root.Game.world.testAction(skill);
						}
					}
				}
			}
		}
		
		public static function PickupItem(id:String):void
		{
			Root.Game.sfc.sendXtMessage("zm", "getDrop", [parseInt(id)], "str", Root.Game.world.curRoom);
		}
		
		public static function GetMapItem(id:String):void
		{
			Root.Game.world.getMapItem(parseInt(id));
		}
		
		public static function Logout():void
		{
			Root.Game.logout();
		}
		
		public static function HasActiveBoost(name:String):String
		{
			name = name.toLowerCase();
			if (name.indexOf("gold") > -1)
				return (Root.Game.world.myAvatar.objData.iBoostG > 0) ? Root.TrueString : Root.FalseString;
			if (name.indexOf("xp") > -1)
				return (Root.Game.world.myAvatar.objData.iBoostXP > 0) ? Root.TrueString : Root.FalseString;
			if (name.indexOf("rep") > -1)
				return (Root.Game.world.myAvatar.objData.iBoostRep > 0) ? Root.TrueString : Root.FalseString;
			if (name.indexOf("class") > -1)
				return (Root.Game.world.myAvatar.objData.iBoostCP > 0) ? Root.TrueString : Root.FalseString;
			return Root.TrueString;
		}
	}
}
