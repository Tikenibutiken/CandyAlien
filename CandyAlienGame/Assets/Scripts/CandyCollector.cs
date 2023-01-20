using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCollector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
        }
    }


}