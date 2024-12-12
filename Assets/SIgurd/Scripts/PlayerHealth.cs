using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentHealth;
    public float maxHealth = 100;

    public TextMeshProUGUI healthText;

    float timeHitByHat = 5;
    float lastTimeHit = 0;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"Health: {currentHealth}";
        lastTimeHit += Time.deltaTime;
    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            GameManager.Instance.isPlayerDead = true;
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SantaHat" && lastTimeHit >= timeHitByHat)
        {
            TakeDamage(25);
        }
    }
}
