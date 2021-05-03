using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Editable variables
    // TODO: assign these values using ScriptableObjects, instead of manually
    public float damage = 1f;
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

        Destroy();
    }

    // helper methods
    public void Initialize(float damage, float lifespan)
    {
        this.damage = damage; this.lifespan = lifespan;
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
