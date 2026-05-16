using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    private Animator animator;
    private int bulletHitCount = 0;
    public int hitsToTrigger = 5; // you can tweak this in Inspector

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            bulletHitCount++;
            Debug.Log("Bullet hit count: " + bulletHitCount);

            if (bulletHitCount >= hitsToTrigger)
            {
                TriggerHitAnimation();
                bulletHitCount = 0; // reset after triggering
            }
        }
        else if (other.gameObject.CompareTag("Sword"))
        {
            TriggerHitAnimation();
        }
    }

    private void TriggerHitAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
    }
}