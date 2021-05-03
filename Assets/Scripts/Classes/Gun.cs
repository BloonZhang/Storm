using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObjects/Gun")]
public class Gun : ScriptableObject
{

	// GameObject/component variables
    public Sprite sprite;

    // basic variables
    public float damage;
    
    // GameObject/component variables
    public GameObject bulletPrefab;

    // basic variables
    public float bulletForce;
    public float bulletsPerSecond;

    // methods
    public void Shoot(Transform firePoint){
    	GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
