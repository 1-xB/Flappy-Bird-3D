using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    [SerializeField] GameObject pipePrefab;
    float spawnTime = 2.5f;
    float pipeCount = 0;

    // ySpawn is the maximum Y of the pipe ( - , + )
    float ySpawn = 2.7f;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 0, spawnTime);
    }

    void SpawnPipe() 
    {
        pipeCount++;
        if (pipeCount > 10 && spawnTime > 0.7f)
        {
            UpdatePipeSettings();
        }
        else 
        {
            Instantiate(pipePrefab, new Vector3(18, Random.Range(-ySpawn, ySpawn), 0), Quaternion.identity);
        }
    }

    void UpdatePipeSettings() 
    {
        // Update the settings
        ySpawn -= 0.1f;
        spawnTime -= 0.1f;
        pipeCount = 0;
        // Cancel the current invoke and start a new one with the updated settings
        CancelInvoke("SpawnPipe");
        InvokeRepeating("SpawnPipe", 0, spawnTime);
    }
}
