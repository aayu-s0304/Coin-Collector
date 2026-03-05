using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerIdentity player = other.GetComponent<PlayerIdentity>();

        if (player != null)
        {
            // Add score to correct player
            ScoreManager.Instance.AddScore(player.playerId, 1);

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}