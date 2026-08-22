using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firemanager : MonoBehaviour
{
    [SerializeField] private Firetrap[] firetraps;
    [SerializeField] private float activationdelay = 1f;
    private void Start()
    {
        StartCoroutine(ActivateTraps());
    }
    private IEnumerator ActivateTraps()
    {
        while (true)
        {
           
            foreach (Firetrap trap in firetraps)
            {
                if (trap != null)
                {
                    trap.ActivateFire();
                }
            }
            yield return new WaitForSeconds(activationdelay);
        }
    }
}
