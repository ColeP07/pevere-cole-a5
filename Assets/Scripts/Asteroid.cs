using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int asteroidSize = 3;
    public Rigidbody2D rb;
    
    void Start()
    {
        //scales the asteroid and its speed depending on its size
        transform.localScale = 0.5f * asteroidSize * Vector2.one;
        rb = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = new Vector2(Random.value - 0.5f, Random.value - 0.5f);
        float speed = Random.Range(4f - asteroidSize, 5f -  asteroidSize);
        rb.AddForce(moveDirection * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        DestroyIfOffscreen();
    }

    private void DestroyIfOffscreen()
    {
        Vector3 position = transform.position;
        if (position.y > 5)
        {
            Destroy(rb.gameObject);
        }
        else if (position.y < -5)
        {
            Destroy(rb.gameObject);
        }
        if (position.x > 9)
        {
            Destroy(rb.gameObject);
        }
        else if (position.x < -9)
        {
            Destroy(rb.gameObject);
        }

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //gets rid of the bullet that hit the asteroid and split it into two smaller asteroids
            Destroy(collision.gameObject);

            if (asteroidSize > 1)
            {
                for(int i = 0; i < 2; i++)
                {
                    Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.asteroidSize = asteroidSize -1;
                }
            }
            
            Destroy(gameObject);
        }
    }
}
