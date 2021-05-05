using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Editable variables
    public float maxHealth;

    // helper variables
    private float currentHealth;

    void Awake()
    {
        Initialize();
    }

    // helper methods
    public void Initialize()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        // Debug.Log(name + " has " + currentHealth + "/" + maxHealth + " HP");
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
