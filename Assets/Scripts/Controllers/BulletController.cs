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
        // Note: We check for parent, because I'm thinking our hitboxes should always be children
        if (col.transform.parent != null)
        {
            GameObject hit = col.transform.parent.gameObject;

            // Check what kind of thing it hit, and then do whatever needs to be done
            if (hit.GetComponent<ObstacleController>() != null) { 
                //Debug.Log("hit an obstacle");
                HitObstacle(hit.GetComponent<ObstacleController>()); 
            }
            // if (col.GetComponent<Enemy>() != null) { relevant enemy hit code }
        }

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

    // hit something methods
    void HitObstacle(ObstacleController obstacle)
    {
        obstacle.TakeDamage(damage);
        Destroy();
    }
}
