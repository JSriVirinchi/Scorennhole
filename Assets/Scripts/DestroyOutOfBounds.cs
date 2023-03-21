using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public GameObject ballPrefab;
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minZ = -5f;
    public float maxZ = 5f;
    private float destroyTime;
    private bool started;

    private void Start()
    {
    }

    // Destroy ball only if the ball has been thrown, 3 seconds have passed since ball has been thrown and ball is outside of the position. 
    void Update()
    {
        if (!started && (Input.GetMouseButtonUp(0)))
        {
            started = true;
            destroyTime = Time.time + 3f;
        }

        if (started && (Time.time > destroyTime))
        {
            Destroy(ballPrefab);
            // Call the SpawnBall method in SpawnManager
            GetComponent<SpawnManager>().SpawnBall();
        }
        else if (transform.position.x < minX || transform.position.x > maxX ||
                 transform.position.z < minZ || transform.position.z > maxZ)
        {
            Destroy(ballPrefab);
            // Call the SpawnBall method in SpawnManager
            GetComponent<SpawnManager>().SpawnBall();
        }
    }
}
