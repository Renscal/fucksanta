using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject player;
    public GameObject visualBody;
    public GameObject explotion;

    [Header("Configurations")]
    public float speed;

    Vector3 playerCoords;

    // Gamecomponents
    ParticleSystem particles;
    Transform playerTR;
    Transform TR;
    AudioSource AS;

    void Start() {
        visualBody.SetActive(true);
        playerTR = player.GetComponent<Transform>();
        TR = GetComponent<Transform>();
        AS = GetComponent<AudioSource>();
        particles = explotion.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        playerCoords = new Vector3(playerTR.position.x, TR.position.y, playerTR.position.z);
        TR.LookAt(playerCoords);
        TR.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        particles.Play();
        visualBody.SetActive(false);
        AS.Play();
    }
}
