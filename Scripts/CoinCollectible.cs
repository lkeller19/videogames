using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
    {
        GhostController controller = other.GetComponent<GhostController>();

        if (controller != null)
        {
            controller.ShowCoin();
            Destroy(gameObject);

            controller.PlaySound(collectedClip);
        }
    }
}
