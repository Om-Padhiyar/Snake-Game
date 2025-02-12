using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject blob;

    [SerializeField]
    public float blobInterval = 3.5f;
    public Vector3 spawnPosition = new Vector3(0, 0, 0);
     private IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnEnemy(blobInterval, blob));
        }
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Debug.Log("Spawning enemy at: " + spawnPosition);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
