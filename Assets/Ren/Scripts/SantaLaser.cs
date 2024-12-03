using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaLaser : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject head;
    public GameObject eye1, eye2;
    public GameObject hat;
    public GameObject player;

    [Header("Configurations")]
    public float laserpower;
    public float turnSpeed;

    [Header("Prefabs")]
    public GameObject laser;

    // Gamecomponents
    Transform headTF;
    Transform hatTF;
    Transform playerTF;

    void Start() {
        headTF = head.GetComponent<Transform>();
        hatTF = hat.GetComponent<Transform>();
        playerTF = player.GetComponent<Transform>();
    }

    void Update() {
        
    }

    protected void rotateTowards(Vector3 to) {

        Quaternion _lookRotation =
            Quaternion.LookRotation(playerTF.position);

        headTF.transform.rotation = _lookRotation;
    }
}
