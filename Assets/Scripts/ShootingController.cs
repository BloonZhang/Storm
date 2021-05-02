using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // GameObject/Component variables
	public Transform firePoint;
	public GameObject bulletPrefab;

    // Editable variables
    // TODO: assign these values using ScriptableObjects, instead of manually
	public float bulletForce = 20f;
    public float bulletsPerSecond = 3f;

    // helper variables
    private float timer_bulletsPerSecond = 0f;

    // Update is called once per frame
    void Update()
    {
        // Update timer(s)
        timer_bulletsPerSecond += Time.deltaTime;

        // Fire input
    	if(Input.GetButton("Fire1")){
            // Check to see if we can fire
            if (timer_bulletsPerSecond > (1f/bulletsPerSecond))
            {
                timer_bulletsPerSecond = 0f;
    		    Shoot();
    	    }
        }
    }

    void Shoot(){
    		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }	
}
