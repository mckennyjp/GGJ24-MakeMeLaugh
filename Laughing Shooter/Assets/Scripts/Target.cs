using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    [SerializeField] private AudioSource crySound;
    [SerializeField] private AudioSource happySound;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        crySound.Stop();
        happySound.Play();
        Destroy(gameObject);
        Debug.Log("Dead");
    }


}
