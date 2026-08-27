using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcollector : MonoBehaviour
{
    [SerializeField] private float healthvalue;

    [SerializeField] private AudioClip pickupSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            soundmanager.instance.PlaySound(pickupSound);
            collision.GetComponent<Health>().AddHealth(healthvalue);
                gameObject.SetActive(false);
        }
    }
}
