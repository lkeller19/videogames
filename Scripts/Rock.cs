using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GhostController controller;
    public AudioClip collectedClip;
    public AudioClip thud;

    void OnCollisionEnter2D(Collision2D other)
    {
        DigDug space = other.gameObject.GetComponent<DigDug>();
        GhostController dug = other.gameObject.GetComponent<GhostController>();

        if(dug != null)
        {
            controller.PlaySound(thud);
        }

        if (space != null)
        {
            Animator speed = other.gameObject.GetComponent<Animator>();
            speed.SetTrigger("death");
            controller.PlaySound(collectedClip);
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (transform.position.y < -44)
        {
            transform.position = new Vector3(-19, -38, 0);
        }
    }
}
