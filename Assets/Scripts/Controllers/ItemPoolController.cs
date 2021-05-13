using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolController : MonoBehaviour
{

	//notes: Class that populates and tracks all items that exist, they are created via the inspector, theoretically no more code needed here ever

    public static Dictionary<string,Item> itemDict = new Dictionary<string,Item>();
    public List<itemIdentifier> itemList = new List<itemIdentifier>();


    [System.Serializable] public struct itemIdentifier{
    	public string name;
    	public Item item;
    }


    void Start(){
    	//HACK #1, I'm keeping count
    	//to populate dictionary through inspector because that isn't possible for some reason ¯\_(ツ)_/¯
    	//honestly this whole class is a hack
    	foreach (itemIdentifier itemId in itemList){
    			itemDict.Add(itemId.name,itemId.item); 
    		}
    	}


    public static Item getItemFromPool(string identifier){
    	return itemDict[identifier];
    }


}
