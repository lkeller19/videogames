using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInenemy : MonoBehaviour
{
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    float fireRate;
    float nextFire;

    public float speed;
    public Transform target;

    Vector2 lookDirection = new Vector2(0, 1);

    public GameObject projectilePrefab;
    Rigidbody2D rigidbody2d;

    private AudioSource audioSource;
    public AudioClip collectedClip;

    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        rigidbody2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
               
            }
        }
        Launch();
    }

    void Launch()
    {
        if (isInvincible)
            return;

        isInvincible = true;
        invincibleTimer = timeInvincible;

        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        BulletController projectile = projectileObject.GetComponent<BulletController>();
        projectile.Launch(lookDirection, 300);
        nextFire = Time.time + fireRate;
        PlaySound(collectedClip);

        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
