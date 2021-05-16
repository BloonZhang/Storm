using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbilityController : MonoBehaviour
{
    // These variables are all set through ScriptableObject.
    [HideInInspector] public float maxTeleportDistance;

    // private variables
    private float playerRadius = 0.45f; // This is the radius of the player's circle collider. TODO: not hardcoded

    public void Initialize()
    {
        // Nothing to do here
    }

    public void TriggerAbility()
    {
        Vector3 directionToTeleport;
        float distanceToTeleport = maxTeleportDistance;

        // if move input, look to teleport to that direction
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            directionToTeleport = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        }
        // if no input, look to teleport to mouse
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            directionToTeleport = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0);
        }
        directionToTeleport = Vector3.Normalize(directionToTeleport);

        // Check if max teleport distance is a valid destination. If so, nothing to do
        Vector3 maxDestination = transform.parent.position + directionToTeleport * distanceToTeleport;
        Vector3 finalDestination;
        if (ValidTeleportDestination(maxDestination)) { finalDestination = maxDestination; }
        // if it's an invalid destination. Check for farthest valid point along teleport path
        /* **** THIS CODE KINDA DOESN'T WORK, SO I'M USING A WORSE SOLUTION
        // do this by casting a raycastall from the player to the destination
        // for each raycast collision, check if destination (minus offset) is valid
        else 
        {
            // Set up raycast and get hits
            Vector2 playerPosition2D = new Vector2(transform.parent.position.x, transform.parent.position.y);
            Vector2 directionToTeleport2D = new Vector2(directionToTeleport.x, directionToTeleport.y);
            RaycastHit2D[] hits = Physics2D.RaycastAll(playerPosition2D, directionToTeleport2D, maxTeleportDistance, ~LayerMask.GetMask("Player"));
            // for each hit, see if it's a valid teleport position. If it is, update farthestValidTeleport
            Vector3 farthestValidTeleport = transform.parent.position;
            float theta = Mathf.Atan2(directionToTeleport2D.y, directionToTeleport2D.x);
            //Debug.Log(theta);
            foreach (RaycastHit2D hit in hits)
            {
                Vector2 pointToCheck = new Vector2(hit.point.x - (playerRadius + 0.1f) * Mathf.Cos(theta), hit.point.y - (playerRadius + 0.1f) * Mathf.Sin(theta));
                if (ValidTeleportDestination(pointToCheck))
                {
                    farthestValidTeleport = pointToCheck;
                }
            }
            maxDestination = farthestValidTeleport;
        }
        */
        // do this by checking every so often along the way for a valid position
        else
        {
            int numberOfIncrements = 25;    // More increments means better teleporting
            finalDestination = transform.parent.position;   // Default: don't move
            for (int i = numberOfIncrements; i > 0; --i)
            {
                Vector3 pointToCheck = transform.parent.position + directionToTeleport * distanceToTeleport * ((float) i / (float) numberOfIncrements);
                if (ValidTeleportDestination(pointToCheck))
                {
                    finalDestination = pointToCheck;
                    break;
                }
            }
        }

        // Finally, teleport the player
        transform.parent.position = finalDestination; 
    }

    // helper methods
    bool ValidTeleportDestination(Vector2 point)
    {
        // Get all layers except player
        // TODO: don't get layers like PlayerBullet either
        return Physics2D.OverlapCircle(new Vector2(point.x, point.y), playerRadius, ~LayerMask.GetMask("Player")) == null;
        //return Physics2D.OverlapCircle(new Vector2(point.x, point.y), playerRadius) == null;
    }

}
