using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadZombieStats : MonoBehaviour
{
    public float health = 50f;

    private void Start()
    {
       
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
