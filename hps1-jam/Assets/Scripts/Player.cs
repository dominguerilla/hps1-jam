using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;

    public UnityEvent onDamage = new UnityEvent();

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
            Debug.Log("Player is dead!");
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthCount.text = $"x {currentHealth}";
    }
}
