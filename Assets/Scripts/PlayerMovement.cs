using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float playerSpeed = 2.5f;
    public float rotationSpeed = 180f;
    public float drag = 2f;
    public float maxSpeed = 10f;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsShipMoving();
        IsShipRotating();
    }

    private void IsShipMoving()
    {
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (isMoving)
        {
            rb.AddForce(playerSpeed * transform.up);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void IsShipRotating()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * transform.forward);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime * transform.forward);
        }
    }
}
