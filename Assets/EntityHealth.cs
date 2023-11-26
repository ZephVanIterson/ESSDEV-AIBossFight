using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public HealthBar bar;
    public float maxHealth;
    private float health;

    private void Start() {
        health = maxHealth;
        // Debug.Log("Health: " + health);
    }
    
    public void Damage(float amount) {
        health -= amount;
        // Debug.Log("Health: " + health + "Damage: " + amount);
        bar.updateHealth(health/maxHealth);
    }
}

