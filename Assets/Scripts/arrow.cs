using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [SerializeField] private float attackcCooldown = 1f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;

        int arrowIndex = FindArrow();

        if (arrowIndex == -1)
            return;

        arrows[arrowIndex].transform.position = firePoint.position;
        arrows[arrowIndex].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }

        return -1;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackcCooldown)
        {
            Attack();
        }
    }
}