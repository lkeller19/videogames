using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigDug : MonoBehaviour
{
    public float speed = 3.0f;

    public float changeTime = 1.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            // Vector3 newScale = transform.localScale;
            //newScale *= -1;
            //transform.localScale = newScale;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }


        Vector2 position = rigidbody2D.position;

        position.x = position.x + Time.deltaTime * speed * direction;
        

            
        

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GhostController player = other.gameObject.GetComponent<GhostController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    public void Kill()
    {
        Destroy(gameObject);

    }
}
