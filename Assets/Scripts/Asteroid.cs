using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float asteroidSize = 3f;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //scales the asteroid depending on its size
        transform.localScale = 0.5f * asteroidSize * Vector2.one;
        rb = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = new Vector2(Random.value - 0.5f, Random.value - 0.5f);
        float speed = Random.Range(4f - asteroidSize, 5f -  asteroidSize);
        rb.AddForce(moveDirection * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfOffscreen();
    }

    public void DestroyIfOffscreen()
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
}
