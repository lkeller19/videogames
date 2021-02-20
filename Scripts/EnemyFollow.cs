using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{


    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    private Rigidbody2D rb;
    private Vector2 movement;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (angle >= 90 || angle <= -90)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GhostController player = other.gameObject.GetComponent<GhostController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
