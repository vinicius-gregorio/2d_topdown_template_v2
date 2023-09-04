using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject dropsPrefab;
    [SerializeField] private int totalDrops;
    [SerializeField] private ParticleSystem leafParticle;

    private bool isCut;

    public void OnHit()
    {
        treeHealth--;
        animator.SetTrigger("isHit");
        leafParticle.Play();
        if (treeHealth <= 0) 
        {
            //Create and init log drops

            for (int i = 0; i < totalDrops; i++)
            {
                animator.SetTrigger("cut");
                Instantiate(dropsPrefab, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f), transform.rotation);
            }

            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("P_Axe") && !isCut)
            {
            OnHit();
            }
    }
}
