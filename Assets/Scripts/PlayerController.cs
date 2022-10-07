using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float pivotSpeed = 5.0f;
    public float jumpPower = 10.0f;

    private float _verticalInput;
    private float _horizontalInput;
    private float _horizontalMouseInput;
    private bool _fire1Input;
    private bool _jumpInput;
    private bool onGround;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // See if input is being given
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        _horizontalMouseInput = Input.GetAxis("Mouse X");
        _fire1Input = Input.GetButtonDown("Fire1");
        _jumpInput = Input.GetButtonDown("Jump");

        // Forward/Backwards
        transform.Rotate(Vector3.up * (_horizontalMouseInput * pivotSpeed));
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed * _verticalInput));


        // Strafing
        transform.Translate(Vector3.right * (_horizontalInput * Time.deltaTime * moveSpeed));

        // Fire
        if (_fire1Input)
        {
            Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        }

        // Jump
        if (_jumpInput && onGround)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}