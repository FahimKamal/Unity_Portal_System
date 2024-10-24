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

    private float test;
}
