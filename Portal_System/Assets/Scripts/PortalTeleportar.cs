using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform receiver;

    private bool m_PlayerIsOverLapping;

    private void Update()
    {
        if (m_PlayerIsOverLapping)
        {
            var portalToPlayer = player.position - transform.position;
            var dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal 
            if (dotProduct < 0f)
            {
                // Teleport player.
                // Rotate the player
                var rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);
                
                // Change the position of player. 
                var positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                m_PlayerIsOverLapping = false;
                Debug.Log("Going to other portal.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_PlayerIsOverLapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_PlayerIsOverLapping = false;
        }
    }
}
