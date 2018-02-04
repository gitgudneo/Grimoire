package grimoire.game
{
	import grimoire.Root;
	
	public class Bank 
	{
		public function Bank() 
		{
			
		}
		
		public static function GetBankItems():String
		{
			return JSON.stringify(Root.Game.world.bankinfo.items);
		}
		
		public static function BankSlots():int
		{
			return Root.Game.world.myAvatar.objData.iBankSlots;
		}
		
		public static function UsedSlots():int
		{
			return Root.Game.world.myAvatar.iBankCount;
		}
		
		public static function TransferToBank(itemName:String):void
		{
			var item:Object = Inventory.GetItemByName(itemName);
			if (item != null)
			{
				Root.Game.world.sendBankFromInvRequest(item);
			}
		}
		
		public static function TransferToInventory(itemName:String):void
		{
			var item:Object = GetItemByName(itemName);
			if (item != null)
			{
				Root.Game.world.sendBankToInvRequest(item);
			}
		}
		
		public static function BankSwap(invItemName:String, bankItemName:String):void
		{
			var invItem:Object = Inventory.GetItemByName(invItemName);
			if (invItem == null) { return; }
			
			var bankItem:Object = GetItemByName(bankItemName);
			if (bankItem == null) { return; }
			
			Root.Game.world.sendBankSwapInvRequest(bankItem, invItem);
		}
		
		public static function GetItemByName(name:String):Object
		{
			if (Root.Game.world.bankinfo.items != null && Root.Game.world.bankinfo.items.length > 0)
			{
				for each (var item:Object in Root.Game.world.bankinfo.items)
				{
					if (item.sName.toLowerCase() == name.toLowerCase())
					{
						return item;
					}
				}
			}
			return null;
		}
		
		public static function Show():void
		{
			Root.Game.world.toggleBank();
		}
		
		public static function LoadBankItems():void
		{
			Root.Game.sfc.sendXtMessage("zm","loadBank",["Sword", "Axe", "Dagger", "Gun", "Bow", "Mace", "Polearm", "Staff", "Wand", "Class", "Armor", "Helm", "Cape", "Pet", "Amulet", "Necklace", "Note", "Resource", "Item", "Quest Item", "ServerUse", "House", "Wall Item", "Floor Item", "Enhancement"],"str",Root.Game.world.curRoom);
		}
	}
}
