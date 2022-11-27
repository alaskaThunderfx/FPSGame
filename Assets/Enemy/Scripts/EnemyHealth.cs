using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }

    // Create a public method which reduces HP by amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead)
            return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
