using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float growthAmount = 0.1f; // how much the player will grow by
    public Sprite newSprite; // new sprite for the player after eating
    public int score = 0; // score counter
    public ParticleSystem particleEffect; // particle effect to play on pickup
    public AudioClip pickupSound; // sound effect to play on pickup

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the player collided with an object with the "Coin" tag
        if (collision.gameObject.CompareTag("Coin"))
        {
            // increase the player's scale by the growth amount
            transform.localScale += new Vector3(growthAmount, growthAmount, 0);

            // change the player's sprite to the new sprite
            GetComponent<SpriteRenderer>().sprite = newSprite;

            // play the particle effect
            if (particleEffect != null)
            {
                Instantiate(particleEffect, collision.transform.position, Quaternion.identity);
            }

            // play the pickup sound effect
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, collision.transform.position);
            }

            // increment the score counter
            score++;

            // destroy the object that was picked up
            Destroy(collision.gameObject);
        }
    }
}