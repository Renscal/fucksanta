using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Kamikaze : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject player;
    public GameObject visualBody;
    public GameObject explotion1;
    public GameObject explotion2;
    public GameObject fuse;

    [Header("Configurations")]
    public float speed;
    bool dead;

    Vector3 playerCoords;

    // Gamecomponents
    ParticleSystem particles1;
    ParticleSystem particles2;
    ParticleSystem fuseParticles;
    Transform playerTR;
    Transform TR;
    AudioSource AS;

    void Start() {
        visualBody.SetActive(true);
        playerTR = player.GetComponent<Transform>();
        TR = GetComponent<Transform>();
        AS = GetComponent<AudioSource>();
        particles1 = explotion1.GetComponent<ParticleSystem>();
        particles2 = explotion2.GetComponent<ParticleSystem>();
        fuseParticles = fuse.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        if(dead == false) {
            playerCoords = new Vector3(playerTR.position.x, TR.position.y, playerTR.position.z);
            TR.LookAt(playerCoords);
            TR.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && dead == false) {
            particles1.Play();
            particles2.Play();
            visualBody.SetActive(false);
            AS.Play();
            dead = true;
            fuseParticles.Stop();
        }
    }
}
