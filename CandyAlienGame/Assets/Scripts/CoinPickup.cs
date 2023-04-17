using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject pickupEffect; // the particle effect to play when the object is picked up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // play the pickup effect
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

            // destroy the coin object
            Destroy(other.gameObject);
        }
    }
}