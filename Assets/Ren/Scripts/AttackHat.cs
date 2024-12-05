using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHat : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject attackHat;
    public GameObject santaHat;

    [Header("Configurations")]
    public float attackInterval;

    //Gamecomponents
    Transform santaHatTF;
    Transform attackHatTF;
    Animator attackHatAnim;


    void Start() {
        santaHatTF = santaHat.GetComponent<Transform>();
        attackHatTF = attackHat.GetComponent<Transform>();
        attackHatAnim = attackHat.GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            santaHat.SetActive(false);
            attackHat.SetActive(true);
            attackHatTF.position = new Vector3(4.58297f, 55.9905f, 20.66323f);
            attackHatTF.rotation = new Quaternion(0, santaHatTF.rotation.y, 0, 0);
            attackHatAnim.SetTrigger("Attack");
        }
    }
}
