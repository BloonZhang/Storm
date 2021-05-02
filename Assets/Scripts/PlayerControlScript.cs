using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    // ***** Variables *****
    // GameObject variables

    // Component variables. Set in Awake()
    // Comopnents are the things you add to gameobjects in the unity editor, 
    // like SpriteRenderer, CircleCollider2D, RigidBody2D, etc.
    private Rigidbody2D my_Rigidbody2D;

    // public Camera cam; // For now we can just use Camera.main. Uncomment once we get multiple cameras

    // Editable variables
    // Change these in the unity inspector. Changing it here will only change the default value
    public float moveSpeedMultiplier = 5f;

    //TODO equip weapon
    // private Weapon equippedWeapon;

    // helper varaibles
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private Vector3 m_Velocity = Vector3.zero; // This is used in Move(). Copied from a tutorial
    Vector2 mousePos;

    // ***** MonoBehaviour methods *****
    // Awake is called before the first frame update
    // Put setup code here
    void Awake()
    {
        // TODO: turn class into a singleton
        // Set up GameObject/Component variables
        my_Rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
       // equippedWeapon = gameObject.AddComponent(typeof(Weapon)) as Weapon;
    //TODO make weapon class with overwriteable attack functions
    }

    // Update is called once per frame
    // Put input-related code here
    void Update()
    {
        // Get player input for movement. This will be used in FixedUpdate()
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeedMultiplier;
        verticalMove = Input.GetAxisRaw("Vertical") * moveSpeedMultiplier;
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // FixedUpdate is called in-step with the physics engine
    // Put physics-related code here
    void FixedUpdate()
    {
        // send horizontalMove and verticalMove (updated in Update()) to Move()
        Move(horizontalMove, verticalMove);
    }


    // ***** Self created methods *****
    // helper methods
    void Move(float horizontalMove, float verticalMove)
    {
        // This was copied from a tutorial.
        // Movement is done through the physics engine, not manually changing the position
        Vector3 targetVelocity = new Vector2(horizontalMove, verticalMove);
        my_Rigidbody2D.velocity = Vector3.SmoothDamp(my_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, 0.05f);

        //Rotation
        Vector2 lookDir = mousePos - my_Rigidbody2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        my_Rigidbody2D.rotation = angle;

    }



}
