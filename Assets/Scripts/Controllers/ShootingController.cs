using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // GameObject/Component variables
	public Transform firePoint;
	public GameObject bulletPrefab;    // Assigned through SO

    private Gun equippedWeapon;

    // helper variables
    private float timer_bulletsPerSecond = 0f;

    // Update is called once per frame
    void Update()
    {
        // Update timer(s)
        timer_bulletsPerSecond += Time.deltaTime;

        // Fire input
        if(equippedWeapon){
            if(Input.GetButton("Fire1")){
                // Check to see if we can fire
                if (timer_bulletsPerSecond > (1f/equippedWeapon.bulletsPerSecond))
                {
                    timer_bulletsPerSecond = 0f;
                    Shoot(firePoint);
                }
            }

        }

    }

    // Helper methods
    void Shoot(Transform firePoint)
    {
        equippedWeapon.Shoot(firePoint);
    }

    public void EquipNewWeapon(Gun newWeapon)  // TODO: make it accept more than just Gun  // TODO: currently public for using button to test
    {
        equippedWeapon = newWeapon;
        GetComponent<SpriteRenderer>().sprite = equippedWeapon.sprite;
    }
}
