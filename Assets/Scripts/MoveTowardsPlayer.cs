using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private GameObject player;
    public float moveSpeed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = player.transform.position;
        transform.LookAt(new Vector3(playerPosition.x, transform.position.y , playerPosition.z));
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
