using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHat : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject attackHat;
    public GameObject santaHat;

    [Header("Configureations")]
    public float attackInterval;

    //Gamecomponents
    Transform santaHatTF;
    Transform attackHatTF;
    Animator attackHatAnim;
    Transform attackHatDadTF;


    void Start() {
        santaHatTF = santaHat.GetComponent<Transform>();
        attackHatTF = attackHat.GetComponent<Transform>();


        Reset();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            
        }
    }

    private void Reset() {
        attackHat.SetActive(true);

        attackHatTF.position = new Vector3(4.58297f, 55.9905f, 20.66323f);
        attackHatTF.rotation = new Quaternion(0, 0, 0, 0);

        attackHat.SetActive(false);
    }
}
