using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ActiveAbility/TeleportAbility")]
public class TeleportAbility : ActiveAbility
{
    /* Inherited
    public string abilityName = "New Default Ability";
    public float abilityBaseCooldown = 1f;
    public Sprite abilityIcon;
    // public AudioClip abilitySound;
    */

    // basic varaibles
    public float teleportDistance;

    // Gameobject/Component variables
    //public ParticleSystem particleSystem;

    private TeleportAbilityController controller;

    // Methods
    public override void Initialize(GameObject playerAbilityControllers)
    {
        // Set the TeleportAbilityController
        controller = playerAbilityControllers.GetComponent<TeleportAbilityController>();
        if (controller == null) { Debug.Log("Error in Initialize() for TeleportAbility.cs"); return; }

        // Set up TeleportAbilityController's variables based on ScriptableObject
        controller.maxTeleportDistance = this.teleportDistance;
    }

    public override void TriggerAbility()
    {
        controller.TriggerAbility();        
    }

}
