using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Transform : MonoBehaviour
{
    public Animator animator;
    public AnimatorOverrideController newController;
    public int score = 0;

    void Update()
    {
        if (score == 4)
        {
            // switch the player animator to a new controller
            animator.runtimeAnimatorController = newController;
        }
    }
}