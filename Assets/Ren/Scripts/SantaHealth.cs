using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaHealth : MonoBehaviour {
    public int currentHealth;
    void Start() {
        
    }

    void Update() {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
