using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxHandler : MonoBehaviour
{
    public Animator myAnimator;

    private string myTag;

    private void Awake()
    {
        myTag = gameObject.tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != myTag)
        {
            EntityManager entityManager;
            entityManager = other.GetComponent<EntityManager>();

            if (entityManager != null && myAnimator.GetBool("isAttacking") == true)
            {
                entityManager.entityHealth -= 20;
                Debug.Log(entityManager.entityHealth);
            }
        }
    }
}
