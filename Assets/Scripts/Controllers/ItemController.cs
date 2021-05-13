using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public Transform equipPoint;
    private Item equippedItem;

    // Update is called once per frame
    void Update()
    {

        // Fire input
        if(equippedItem){
            if(Input.GetButton("Fire1")){
                // Debug.Log("Used item");
                useItem();
            }
            // Update timer(s)
            equippedItem.timer_useRate += Time.deltaTime;

        }

    }

    // Helper methods
    void useItem()
    {
        equippedItem.Action(equipPoint);
    }

    public void EquipNewItem(int index) 
    {
        //equips item based on the index of the players inventory: see inventoryController
        //notes: everything I'm doing to make this work is static, if we ever want to make instances of inventories it will need a rework with a proper object. IE Multiplayer
        equippedItem = InventoryController.getInventoryItem(index);
        GetComponent<SpriteRenderer>().sprite = equippedItem.sprite;
    }

    public void PutItemInInventory(string indexAndName){
        //notes: this function only exists as a way to equip items with the demo buttons, maybe remove inventoryController.

        //HACK #2
        //onClick events can only take one argument, I need to pass in the index AND the ID, so we split on the comma
        //at least this one hopefully won't be needed later, it's only triggered by the button for testing
        string[] splitParams = indexAndName.Split(',');

        InventoryController.addItemToInventory(splitParams[0], int.Parse(splitParams[1]));
    }
}
