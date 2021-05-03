using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObjects/Gun")]
public class Gun : Item
{

	// GameObject/Component variables
	public GameObject bulletPrefab;    // Assigned through SO

    // basic variables
    public float damage;

    // basic variables
    public float bulletForce;
    public float bulletsPerSecond;

    // methods
    public override void Action(Transform equipPoint){

         if (timer_useRate > (1f/bulletsPerSecond))
        {
            timer_useRate = 0f;

            GameObject bullet = Instantiate(bulletPrefab, equipPoint.position, equipPoint.rotation);
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.AddForce(equipPoint.up * bulletForce, ForceMode2D.Impulse);
           
        }

    }
}
