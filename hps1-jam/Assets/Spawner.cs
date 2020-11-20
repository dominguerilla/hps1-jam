using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject monsterPrefab;

    [Header("Spawn Points")]
    [SerializeField] Transform[] playerSpawnpoints;
    [SerializeField] Transform[] monsterSpawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject(playerPrefab, playerSpawnpoints);
        SpawnObject(monsterPrefab, monsterSpawnpoints);
    }

    public void SpawnObject(GameObject prefab, Transform[] spawnPoints)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject.Instantiate(prefab, spawnPoint.position + new Vector3(0, 1f, 0), prefab.transform.rotation);
    }
}
