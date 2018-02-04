﻿package grimoire.game
{
	import grimoire.Root;
	import grimoire.game.Inventory;
	
	public class Shops 
	{
		public function Shops() 
		{
			
		}
		
		public static var LoadedShops:Array = [];
		
		public static function OnShopLoaded(shop:Object):void
		{
			var loadedShop:Object = new Object();
			loadedShop.Location = shop.Location;
			loadedShop.sName = shop.sName;
			loadedShop.ShopID = shop.ShopID;
			loadedShop.items = [];
			var i:int = 0;
			while (i < shop.items.length)
			{
				loadedShop.items.push(shop.items[i]);
				i++;
			}
			LoadedShops.push(loadedShop);
		}
		
		public static function ResetShopInfo():void
		{
			Root.Game.world.shopinfo = null;
		}
		
		public static function IsShopLoaded():String
		{
			return (Root.Game.world.shopinfo != null &&
				   Root.Game.world.shopinfo.items != null &&
				   Root.Game.world.shopinfo.items.length > 0) ? Root.TrueString : Root.FalseString;
		}
		
		public static function BuyItem(name:String):void
		{
			var item:Object = GetShopItem(name.toLowerCase());
			if (item != null)
				Root.Game.world.sendBuyItemRequest(item);
		}
		
		public static function GetShopItem(name:String):Object
		{
			var i:int = 0;
			while (i < Root.Game.world.shopinfo.items.length)
			{
				var item:Object = Root.Game.world.shopinfo.items[i];
				if (item.sName.toLowerCase() == name)
					return item;
				i++;
			}
			return null;
		}
		
		public static function GetShops():String
		{
			return JSON.stringify(LoadedShops);
		}
		
		public static function Load(id:String):void
		{
			Root.Game.world.sendLoadShopRequest(parseInt(id));
		}
		
		public static function LoadHairShop(id:String):void
		{
			Root.Game.world.sendLoadHairShopRequest(parseInt(id));
		}
		
		public static function LoadArmorCustomizer():void
		{
			Root.Game.openArmorCustomize();
		}
		
		public static function SellItem(name:String):void
		{
			var item:Object = Inventory.GetItemByName(name);
			Root.Game.world.sendSellItemRequest(item);
		}
	}
	
}
