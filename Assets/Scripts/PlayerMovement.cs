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
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool isInvincible = false;
    public float invinceDuration = 2f;
    public float invinceTimer = 0f;
    public UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is invincible, it counts the timer down until it expires, then makes the player not invincible
        if (isInvincible)
        {
            invinceTimer -= Time.deltaTime;

            if (invinceTimer <= 0 )
            {
                isInvincible = false;
            }
        }

        if (uiManager.playerLives ==  0)
        {
            uiManager.playerLives = 3;
        }
        IsShipMoving();
        IsShipRotating();
        IsOffScreen();
        IsShooting();

        
    }

    private void IsShipMoving()
    {
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (isMoving)
        {
            rb.AddForce(playerSpeed * transform.up);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            rb.velocity -= rb.velocity * drag * Time.deltaTime;
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

    private void IsOffScreen()
    {
        Vector3 position = transform.position;
        if (position.y > 5)
        {
            position.y = -5;
        }
        else if (position.y < -5)
        {
            position.y = 5;
        }
        if (position.x > 9)
        {
            position.x = -9;
        }
        else if (position.x < -9)
        {
            position.x = 9;
        }

        transform.position = position;
    }

    private void IsShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid") && !isInvincible)
        {
            //resets player back to start position
            transform.position = Vector2.zero;

            //give player some invincibility when they hit an asteroid
            isInvincible = true;
            invinceTimer = invinceDuration;

            //decrease lives when hit
            uiManager.RemoveLives();
        }
    }
}
