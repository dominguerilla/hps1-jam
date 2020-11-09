using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;

    public UnityEvent onDamage = new UnityEvent();

    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
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
    }
}
