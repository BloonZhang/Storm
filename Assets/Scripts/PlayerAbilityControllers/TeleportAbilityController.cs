using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbilityController : MonoBehaviour
{
    // These variables are all set through ScriptableObject.
    [HideInInspector] public float teleportDistance;

    public void Initialize()
    {
        // Nothing to do here
    }

    public void TriggerAbility()
    {
        Debug.Log("teleport");
        // Get mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Get normalized vector towards mouse position
        Vector3 vectorTowardsMouse = new Vector3(mousePosition.x - transform.position.x,
                                                    mousePosition.y - transform.position.y,
                                                    0);
        vectorTowardsMouse = Vector3.Normalize(vectorTowardsMouse);
        Debug.Log(vectorTowardsMouse);

        // Teleport player towards mouse position
        // TODO: move player if player teleports into a wall or something
        transform.parent.position = transform.parent.position + vectorTowardsMouse * teleportDistance;
    }


}
