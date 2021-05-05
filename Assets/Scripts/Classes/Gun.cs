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
    public float bulletForce;
    public float bulletsPerSecond;
    public float bulletLifespan; 

    // methods
    public override void Action(Transform equipPoint){

         if (timer_useRate > (1f/bulletsPerSecond))
        {
            timer_useRate = 0f;

            // Create bullet
            GameObject bullet = Instantiate(bulletPrefab, equipPoint.position, equipPoint.rotation);
            if (bullet.GetComponent<BulletController>()) // TODO: should this be a try catch?
            {             
                bullet.GetComponent<BulletController>().Initialize(damage, bulletLifespan);
            }
            else { Debug.Log("Instantiated bulletPrefab in Gun " + name + " has no BulletController"); }
            // Put bullet into motion
			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
			rb.AddForce(equipPoint.up * bulletForce, ForceMode2D.Impulse);
        }

    }
}
