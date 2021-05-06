using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // We are using the UI
using TMPro;            // Using TextMeshPro instead of built-in unity text

public class AbilityController : MonoBehaviour
{

    public string abilityButtonAxisName = "Fire1";
    public Image icon;
    public Image darkMask;
    public TextMeshProUGUI coolDownTextDisplay;
    // private AudioSource abilitySource;       // TODO: add AudioSource

    [SerializeField] private ActiveAbility ability;   // TODO: remove SerializeField. Set through Initialize()
    [SerializeField] private GameObject playerAbilityControllers; // TODO: remove SerializeField. Set through Initialize()
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;


    void Start()
    {
        // TODO: eventually will be initialized elsewhere, so we won't need [SerializeField] up top
        // Right now it's hardcoded for testing purposes
        Initialize(ability, playerAbilityControllers);    
    }

    void Update()
    {
        // If the ability can be used again
        if (Time.time > nextReadyTime)
        {
            AbilityReady();
            // If the button is pressed
            if (Input.GetButtonDown(abilityButtonAxisName))
            {
                ButtonTriggered();
            }
        }
        // If the ability is still on cooldown
        else
        {
            CoolDown();
        }
    }


    // Helper methods
    public void Initialize(ActiveAbility selectedAbility, GameObject playerAbilityControllers)
    {
        // Set ScriptableObject
        ability = selectedAbility;

        // Start getting info from ScriptableObject
        icon.sprite = ability.abilityIcon;
        darkMask.sprite = ability.abilityIcon;
        coolDownDuration = ability.abilityBaseCooldown;
        ability.Initialize(playerAbilityControllers);
        AbilityReady();
    }
    void AbilityReady() // Called every frame the ability is ready
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }
    void CoolDown() // Called every frame when ability is on cooldown
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCD = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCD.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }
    void ButtonTriggered()  // What to do when button is pressed
    {
        nextReadyTime = Time.time + coolDownDuration;
        coolDownTimeLeft = coolDownDuration;
        coolDownTextDisplay.enabled = true;
        darkMask.enabled = true;
        // abilitySource.clip = ability.abilitySound;
        // abilitySource.Play();

        ability.TriggerAbility();
    }

}
