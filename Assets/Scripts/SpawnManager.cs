using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnDelay = 5.0f;
    private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void spawnObject()
    {
        Instantiate(Enemy, transform.position + (Vector3.up * 1), transform.rotation);
    }
}