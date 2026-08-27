using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeenemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderdistance;
    [SerializeField] private BoxCollider2D boxCollider;


    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldowntimer = Mathf.Infinity;

    [Header("Arrack sound")]
    [SerializeField] private AudioClip attackSound;

    private Animator anim;
    private Health playerhealth;

    private enemypatroling enemy;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponentInParent<enemypatroling>();
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldowntimer >= attackCooldown && playerhealth.currentHealth > 0)
            {
                cooldowntimer = 0;
                anim.SetTrigger("meleeAttack");
                soundmanager.instance.PlaySound(attackSound);
            }
        }

        if (enemy != null)
            enemy.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast
            (boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
             0, Vector2.left, 0,playerLayer );

        if(hit.collider != null)
            playerhealth = hit.transform.GetComponent<Health>();

        return hit.collider != null; 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderdistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        
            playerhealth.TakeDamage(damage);

        
    }


}
