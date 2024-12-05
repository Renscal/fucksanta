using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
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
    //public GameObject laser;

    [Header("Materials")]
    public Material blackEyeMat;
    public Material redEyeMat;

    // Gamecomponents
    Transform headTF;
    Transform hatTF;
    Transform playerTF;
    Animator anim;

    void Start() {
        // Call components
        headTF = head.GetComponent<Transform>();
        hatTF = hat.GetComponent<Transform>();
        playerTF = player.GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        // Stare at player
        headTF.LookAt(player.transform);
    }
}
