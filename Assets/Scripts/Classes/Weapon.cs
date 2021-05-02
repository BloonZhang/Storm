using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract base class for all weapons equipped by player
public abstract class Weapon : ScriptableObject
{
    // GameObject/component variables
    public Sprite sprite;

    // basic variables
    public string name;
    public float damage;
}
