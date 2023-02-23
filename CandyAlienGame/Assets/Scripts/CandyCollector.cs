using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyCollector : MonoBehaviour
{
    public Animator SlimeBob_5;
    public AudioSource EatSound;
    private void start()
    {

    }

    public int CandyMeter = 0;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
            EatSound.Play();
            CandyMeter = CandyMeter+1;
        }




    }


}