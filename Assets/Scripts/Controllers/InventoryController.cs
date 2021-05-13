using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

	//notes: may not be necessary to have a seperate inventory controller, all of this could be done in Itemcontroller, thoughts?


   public static List<Item> inventory = new List<Item>();

   public static Item getInventoryItem(int index){
   		return inventory[index];
   }

   public static void addItemToInventory(string itemName, int index){
   		//TODO account for max inventory size, allow items to be set to specific indices
   		inventory.Add(ItemPoolController.getItemFromPool(itemName));
   }
}
