using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnTimer = 15;
    private float spawnethtimeth;
    private Transform spawnPos;
    public GameObject spawnObject;
    public float spawnRadius = 10;

    // Start is called before the first frame update
    void Start() {
        spawnethtimeth = spawnTimer;
    }

    // Update is called once per frame
    void Update() {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) {
            Instantiate(spawnObject, transform.position, Quaternion.identity);
            spawnTimer = spawnethtimeth;
        }
    }
}
