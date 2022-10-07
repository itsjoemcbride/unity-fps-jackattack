using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        
        // Destroy if out of bounds
        if (transform.position.x > 30 || transform.position.x < -30 || transform.position.z > 30 || transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");

        // if an enemy is hit
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}