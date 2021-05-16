using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbility : ScriptableObject
{
    // basic variables
    public string abilityName = "New Default Ability";
    public float abilityBaseCooldown = 1f;

    // GameObject/Component variables
    public Sprite abilityIcon;
    // public AudioClip abilitySound;   // TODO: add sound

    // Methods
    // Input: the AbilityControllers of the player. 
    // Depending on the ability, it will GetComponent() a differet component of the player.
    // Ex. TeleportAbility class will call playerAbilityControllers.GetComponent<TeleportController>()
    public abstract void Initialize(GameObject playerAbilityControllers);
    public abstract void TriggerAbility();
}
