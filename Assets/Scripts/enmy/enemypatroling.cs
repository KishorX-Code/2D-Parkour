using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypatroling : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingleft;

    [Header ("Idel Dehaviour")]
    [SerializeField]  private float idelDuration;
    private float idelTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {

        if (movingleft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();

            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idelTimer += Time.deltaTime;

        if(idelTimer > idelDuration)
        movingleft = !movingleft;
    }

    private void MoveInDirection(int _direction)
    {
        idelTimer = 0;
        anim.SetBool("moving", true);

        enemy.localScale
             = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);

    }
}
