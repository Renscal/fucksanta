using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AttackHat : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject attackHat;
    public GameObject attackHatDad;
    public GameObject santaHat;

    [Header("Configurations")]
    public float attackInterval;

    //Gamecomponents
    Transform santaHatTF;
    Transform attackHatTF;
    Transform attackHatDadTF;
    Animator attackHatAnim;


    void Start() {
        santaHatTF = santaHat.GetComponent<Transform>();
        attackHatTF = attackHat.GetComponent<Transform>();
        attackHatDadTF = attackHatDad.GetComponent<Transform>();
        attackHatAnim = attackHat.GetComponent<Animator>();
        attackHat.SetActive(true);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            santaHat.SetActive(false);
            attackHat.SetActive(true);
            attackHatDadTF.rotation = new Quaternion(0, santaHatTF.rotation.y, 0, 0);
            attackHatAnim.SetTrigger("Attack");
        }
    }
}
