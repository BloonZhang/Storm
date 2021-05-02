using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObjects/Gun")]
public class Gun : Weapon
{
    // GameObject/component variables
    public BulletController bulletPrefab;

    // basic variables
    public float bulletsPerSecond;
}
