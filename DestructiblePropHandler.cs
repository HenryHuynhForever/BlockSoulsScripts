using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePropHandler : MonoBehaviour
{
    private EntityManager myEntityManager;

    private void Awake()
    {
        myEntityManager = GetComponent<EntityManager>();
    }

    private void Update()
    {
        if (myEntityManager.entityHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
