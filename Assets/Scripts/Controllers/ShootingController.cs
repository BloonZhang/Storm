using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // GameObject/Component variables
	public Transform firePoint;
	public GameObject bulletPrefab;    // Assigned through SO

    // ScriptableObject variables
    private string my_name;
    private float my_damage;
	private float my_bulletForce;
    private float my_bulletsPerSecond;
    private Sprite my_sprite;

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
            if (timer_bulletsPerSecond > (1f/my_bulletsPerSecond))
            {
                timer_bulletsPerSecond = 0f;
    		    Shoot();
    	    }
        }
    }

    // Helper methods
    void Shoot()
    {
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * my_bulletForce, ForceMode2D.Impulse);
    }
    public void EquipNewWeapon(Gun newWeapon)  // TODO: make it accept more than just Gun  // TODO: currently public for using button to test
    {
        my_name = newWeapon.name;
        my_damage = newWeapon.damage;
        my_bulletForce = newWeapon.bulletForce;
        my_bulletsPerSecond = newWeapon.bulletsPerSecond;
        my_sprite = newWeapon.sprite; GetComponent<SpriteRenderer>().sprite = my_sprite;
    }
}
