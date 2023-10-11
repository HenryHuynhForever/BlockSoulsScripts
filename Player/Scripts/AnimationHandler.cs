using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void OnAttackEnd()
    {
        myAnimator.SetBool("isAttacking", false);
    }

    public void OnAnimationEnd(string boolName)
    {
        myAnimator.SetBool(boolName, false);
    }
}
