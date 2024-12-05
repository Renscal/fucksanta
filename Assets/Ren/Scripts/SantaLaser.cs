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
    public float laserSpeed;
    public float laserFireRate = 0.1f;
    float lastTimeFiredLaster = 0;
    public float turnSpeed;

    [Header("Prefabs")]
    //public GameObject laser;

    [Header("Materials")]
    public Material blackEyeMat;
    public Material redEyeMat;

    [Header("Laser Stuff")]
    [Range(0,3)] public float laserDamping;
    Vector3 chasePosition;
    public LineRenderer laserEye1;
    public LineRenderer laserEye2;

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

        chasePosition = Vector3.MoveTowards(chasePosition, player.transform.position, laserSpeed * Time.deltaTime);
        laserEye1.SetPosition(0, eye1.transform.position);
        laserEye1.SetPosition(1, chasePosition);
        laserEye2.SetPosition(0, eye2.transform.position);
        laserEye2.SetPosition(1, chasePosition);

        lastTimeFiredLaster += Time.deltaTime;
        if(lastTimeFiredLaster>= laserFireRate)
        {
            lastTimeFiredLaster = 0;
            if(Vector3.Distance(chasePosition, player.transform.position) < 2 && GameManager.Instance.isPlayerDead == false)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(2);
            }
        }
        // Stare at player
        Vector3 lookDirecion = player.transform.position - headTF.position;
        headTF.rotation = Quaternion.Slerp(head.transform.rotation, Quaternion.LookRotation(lookDirecion.normalized), turnSpeed * Time.deltaTime);
        {
          

        }
    }
}
