using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Pool", menuName = "ScriptableObjects/ItemPool")]
public class ItemPool : ScriptableObject
{
    public string description;
    public List<Item> items;

    // TODO: some way to access items. Maybe GetItemById(int), GetItemByDescription(str)?
    // TODO: some way to add/remove items
}
