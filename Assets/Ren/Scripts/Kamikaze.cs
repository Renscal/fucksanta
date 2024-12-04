using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject player;

    [Header("Configurations")]
    public float speed;

    Vector3 playerCoords;

    // Gamecomponents
    Transform playerTR;
    Transform TR;

    void Start() {
        playerTR = player.GetComponent<Transform>();
        TR = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        playerCoords = new Vector3(playerTR.position.x, TR.position.y, playerTR.position.z);
        TR.LookAt(playerCoords);
        TR.Translate(0, 0, speed * Time.deltaTime);
    }
}
