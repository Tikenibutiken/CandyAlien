using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float growthAmount = 0.1f; // how much the player will grow by
    public Sprite newSprite; // new sprite for the player after eating
    public int score = 0; // score counter

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the player collided with an object with the "coin" tag
        if (collision.gameObject.CompareTag("Coin"))
        {
            // increase the player's scale by the growth amount
            transform.localScale += new Vector3(growthAmount, growthAmount, 0);

            // change the player's sprite to the new sprite
            GetComponent<SpriteRenderer>().sprite = newSprite;

            // destroy the object that was eaten
            Destroy(collision.gameObject);

            // increment the score counter
            score++;
        }
    }
}