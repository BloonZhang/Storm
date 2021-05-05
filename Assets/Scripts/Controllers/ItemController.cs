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

    public void EquipNewItem(Item newItem)  // TODO: make it accept more than just Gun  // TODO: currently public for using button to test
    {
        equippedItem = newItem;
        GetComponent<SpriteRenderer>().sprite = equippedItem.sprite;
    }
}
