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
        Vector3 vectorToTeleport;

        // if move input, teleport to that direction
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            vectorToTeleport = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        }
        // if no input, teleport to mouse
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            vectorToTeleport = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0);
        }
        vectorToTeleport = Vector3.Normalize(vectorToTeleport);

        // Actually teleport player
        // TODO: move player if player teleports into a wall or something
        transform.parent.position = transform.parent.position + vectorToTeleport * teleportDistance;
    }


}
