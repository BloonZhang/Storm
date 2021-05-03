using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Editable variables
    // TODO: assign these values using ScriptableObjects, instead of manually
    public float lifespan = 1.5f;

    // helper variables
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Check lifespan of bullet
        timer += Time.deltaTime;
        if (timer > lifespan) { Destroy(); }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // TODO: do damage to whatever it hit

        // Note: I 
        Destroy();
    }

    // helper methods
    void Destroy()
    {
        Destroy(gameObject);
    }
}
