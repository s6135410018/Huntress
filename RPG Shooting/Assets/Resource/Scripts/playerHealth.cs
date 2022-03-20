using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerHealth : MonoBehaviour
{
    [SerializeField] Slider slider;
    int currentHealth = 0;
    int maxHealth = 10;
    Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        animator = GetComponent<Animator>();
    }
    
    public void UpdateHealth(int damage)
    {
        currentHealth -= damage;
        slider.value = Mathf.Lerp(currentHealth, maxHealth, 0.1f);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetTrigger("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
