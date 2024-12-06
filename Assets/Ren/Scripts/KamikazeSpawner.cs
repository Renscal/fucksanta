using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KamikazeSpawner : MonoBehaviour {
    public List<GameObject> spawnPoints;
    public GameObject prefab;
    public float cooldownSeconds;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public IEnumerator SpawnPrefab(Vector3 position, Quaternion rotation) {
        yield return new WaitForSeconds(cooldownSeconds);

        int randomIndex = Random.Range(0, spawnPoints.Count);

        //Instantiate(prefab, );
    }
}
