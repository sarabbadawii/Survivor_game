using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private bool attackingActive = false;
    private PlayerScript player;
    public GameOverScript gameManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = FindObjectOfType<PlayerScript>();
    }

    public virtual void Attack()
    {
        if(attackingActive == true)
        {
            return;
        }
        attackingActive = true;
        StartCoroutine(AttackCoroutine());
        
    }
    public virtual void StopAttack()
    {
        attackingActive=false;
    }
    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("Attack", true);
        while(attackingActive ==true)
        {
            if (playerHealth)
            {
                playerHealth.DecreaseHealth(5);
            }
            if (!player)
            {
                gameManager.gameOver();
                animator.SetBool("Attack", false);
                break;
            }
            yield return (new WaitForSeconds(2));
        }
    }
}
