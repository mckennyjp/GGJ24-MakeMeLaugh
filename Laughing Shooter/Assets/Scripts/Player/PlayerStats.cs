using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public float currentHealth;

    [SerializeField] private AudioSource hurtSound;

    public HealthBar healthBar;
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20f);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            hurtSound.Play();
            Debug.Log("you are hurt");
            TakeDamage(20f);
        }
    }

    private void Die()
    {
        Debug.Log("You are depressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
