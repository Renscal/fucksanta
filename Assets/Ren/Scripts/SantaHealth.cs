using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SantaHealth : MonoBehaviour {

    Transform santa;

    public float currentHealth;
    public float maxHealth = 1000;

    public Slider healthSlider;

    public GameObject nukeVFX;
    public AudioClip santaDiesSFX;
    public AudioClip hereComesTheSun;
    public AudioClip BoomSFX;

    public bool isDead = false;

    void Start() {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.fillRect.gameObject.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);
        santa = transform.parent.parent;
    }

    void Update() {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        healthSlider.fillRect.gameObject.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, currentHealth / maxHealth);
        if (currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            StartCoroutine(SantaDie());
        }
    }
    IEnumerator SantaDie()
    {
        Camera.main.GetComponent<AudioSource>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(santaDiesSFX);
        yield return new WaitForSeconds(santaDiesSFX.length - 0.1f);
        nukeVFX.SetActive(true);
        nukeVFX.GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().PlayOneShot(BoomSFX);
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().PlayOneShot(hereComesTheSun);
        GameManager.Instance.winScreen.SetActive(true);
        yield return new WaitForSeconds(1f);

    }
}
