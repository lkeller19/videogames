using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalagaBullet : MonoBehaviour
{
    Rigidbody2D rd;
    public float speed;

    private Transform player;
    private Vector3 target;

    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;


    }

    // Update is called once per frame
    void Update()
    {
        rd.position = Vector2.MoveTowards(rd.position, player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GhostController player = other.gameObject.GetComponent<GhostController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }

        FollowAI ship = other.gameObject.GetComponent<FollowAI>();

        if (ship != null)
        {
            return;
        }

        Destroy(gameObject);

    }
}

