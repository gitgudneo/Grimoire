package grimoire.game
{
	import grimoire.Root;
	public class World 
	{
		public static function MapLoadComplete():String
		{
			if (!Root.Game.world.mapLoadInProgress)
			{
				try
				{
					return (Root.Game.getChildAt(Root.Game.numChildren - 1) != Root.Game.mcConnDetail) ? Root.TrueString : Root.FalseString;
				}
				catch (e:*)
				{
					return Root.FalseString;
				}
			}
			return Root.FalseString;
		}
		
		public static function PlayersInMap():String
		{
			return JSON.stringify(Root.Game.world.areaUsers);
		}
		
		public static function IsActionAvailable(action:String):String
		{
			var _loc_2:* = undefined;
            var _loc_3:* = undefined;
            var _loc_4:* = undefined;
            var _loc_5:* = undefined;
            _loc_2 = Root.Game.world.lock[action];
            _loc_3 = new Date();
            _loc_4 = _loc_3.getTime();
            _loc_5 = _loc_4 - _loc_2.ts;
			return (_loc_5 < _loc_2.cd ? Root.FalseString : Root.TrueString);
		}
		
		public static function GetMonstersInCell():String
		{
			var mons:Array = Root.Game.world.getMonstersByCell(Root.Game.world.strFrame);
			var ret:Array = [];
			for (var id:Object in mons)
			{
				var m:Object = mons[id];
				var mon:Object = new Object();
				mon.sRace = m.objData.sRace;
				mon.strMonName = m.objData.strMonName;
				mon.MonID = m.dataLeaf.MonID;
				mon.iLvl = m.dataLeaf.iLvl;
				mon.intState = m.dataLeaf.intState;
				mon.intHP = m.dataLeaf.intHP;
				mon.intHPMax = m.dataLeaf.intHPMax;
				ret.push(mon);
			}
			return JSON.stringify(ret);
		}
		
		public static function GetVisibleMonstersInCell():String
		{
			var mons:Array = Root.Game.world.getMonstersByCell(Root.Game.world.strFrame);
			var ret:Array = [];
			for (var id:Object in mons)
			{
				var m:Object = mons[id];
				if (m.pMC == null || !m.pMC.visible || m.dataLeaf.intState <= 0)
					continue;
				var mon:Object = new Object();
				mon.sRace = m.objData.sRace;
				mon.strMonName = m.objData.strMonName;
				mon.MonID = m.dataLeaf.MonID;
				mon.iLvl = m.dataLeaf.iLvl;
				mon.intState = m.dataLeaf.intState;
				mon.intHP = m.dataLeaf.intHP;
				mon.intHPMax = m.dataLeaf.intHPMax;
				ret.push(mon);
			}
			return JSON.stringify(ret);
		}
		
		public static function SetSpawnPoint():void
		{
			Root.Game.world.setSpawnPoint(Root.Game.world.strFrame, Root.Game.world.strPad);
		}
		
		public static function IsMonsterAvailable(name:String):String
		{
			return GetMonsterByName(name) != null ? Root.TrueString : Root.FalseString;
		}
		
		public static function GetSkillName(index:String):String
		{
			var i:int = parseInt(index);
			return "\"" + Root.Game.world.actions.active[i].nam + "\"";
		}
		
		public static function GetMonsterByName(name:String):Object
		{
			for each (var mon:Object in Root.Game.world.getMonstersByCell(Root.Game.world.strFrame))
			{
				var monster:String = mon.pMC.pname.ti.text.toLowerCase();
				if (((monster.indexOf(name.toLowerCase()) > -1) || (name == "*")) && mon.dataLeaf.intState > 0)
				{
					return mon;
				}
			}
			return null;
		}
		
		public static function GetCells():String
		{
			var cells:Array = [];
			for each (var cell:Object in Root.Game.world.map.currentScene.labels)
				cells.push(cell.name);
			return JSON.stringify(cells);
		}
		
		public static function GetItemTree():String
		{
			var items:Array = [];
			
			for (var id:String in Root.Game.world.invTree)
			{
				items.push(Root.Game.world.invTree[id]);
			}
			
			return JSON.stringify(items);
		}
		
		public static function RoomId():String
		{
			return Root.Game.world.curRoom.toString();
		}
	}
}
