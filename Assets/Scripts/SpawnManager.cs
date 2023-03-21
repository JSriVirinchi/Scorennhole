using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] cups;
    public GameObject ballPrefab;
    private Vector3 spawnPos = new Vector3 (0.18f, -0.5f, -0.5f);
    private float startDelay = 1;
    private float repeatRate = 1;

    private void Start()

    // Spawn a ball and repeat with start delay and repeat rate. 
    {
        InvokeRepeating("SpawnBall", startDelay, repeatRate);
    }
    
    // Spawn a ball only if ther is no other ball in the scene. 
    public void SpawnBall()
    {
        if(GameObject.FindWithTag("Ball") == null)
        {
            Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        }
    }
}

