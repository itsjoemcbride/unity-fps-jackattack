using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _mouseInput;
    public float pivotSpeed = 5.0f;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _mouseInput = Input.GetAxis("Mouse X");
        _verticalInput = Input.GetAxis("Vertical");
        
        // Rotates the camera around the player according to mouse move
        transform.Rotate(Vector3.up * (_mouseInput * pivotSpeed));
    }
}