using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // Reference to the player's transform
    public Vector3 offset;     // Offset of the camera from the player
    public float smoothTime = 0.3f;  // Smoothing time for camera movement
    private Vector3 velocity = Vector3.zero;
void Awake()
    {
        // Example: Find the player by tag if not manually assigned
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

            if (target == null)
            {
                Debug.LogError("CameraFollow: Player not found! Please assign the player or ensure it has the 'Player' tag.");
            }
        }

        // Add any other initialization code here
        Debug.Log("CameraFollow script has awakened!");
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the target position with the specified offset
            Vector3 targetPosition = target.position + offset;

            // Keep the Z-axis at a fixed value (e.g., -10)
            targetPosition.z = -10;

            // Smoothly interpolate between the current position and target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}