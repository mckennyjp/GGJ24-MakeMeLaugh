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
            StartCoroutine(DeathSound());
        }
    }

    void Die()
    {
        crySound.Stop();
        Destroy(gameObject);
        Debug.Log("Dead");
    }

    IEnumerator DeathSound()
    {
        happySound.Play();
        yield return new WaitForSeconds(1f);
        Die();
    }


}
