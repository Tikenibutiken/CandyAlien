using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTransform2 : MonoBehaviour
{
    public Animator animator;
    public AnimatorOverrideController newController;
    public Grow growScript;

    void Update()
    {
        if (growScript.score == 4)
        {
            // switch the player animator to a new controller
            animator.runtimeAnimatorController = newController;
        }
    }
}