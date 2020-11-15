using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;

    public UnityEvent onDamage = new UnityEvent();
    public UnityEvent onDeath = new UnityEvent();

    [SerializeField] Text healthCount;

    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void ChangeHealth(int amount)
    {
        int originalHealth = currentHealth;
        currentHealth += amount;
        if (currentHealth < originalHealth)
        {
            onDamage.Invoke();
        }
        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthCount.text = $"x {currentHealth}";
    }

    public void ResetPlayer()
    {
        this.currentHealth = maxHealth;
        UpdateUI();
    }
}
