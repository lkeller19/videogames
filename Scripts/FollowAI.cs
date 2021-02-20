using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    Vector2 lookDirection = new Vector2(1, 0);
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    public GameObject projectilePrefab;

    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    private Rigidbody2D rigidbody2d;
    private Vector2 movement;
    Animator animator;

    public AudioClip collectedClip;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidbody2d.rotation = angle;

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;

            }
        }
        Launch();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
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

    void Launch()
    {
        if (isInvincible)
            return;

        isInvincible = true;
        invincibleTimer = timeInvincible;



        Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);
        PlaySound(collectedClip);


    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
