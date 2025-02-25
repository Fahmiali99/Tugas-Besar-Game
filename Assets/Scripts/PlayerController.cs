using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public bool inAir = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Update()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
            rb.AddForce(new Vector3(0, 35, 0), ForceMode.Impulse);
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
            inAir = false;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
            inAir = true;
    }

}
