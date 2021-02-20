using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// some of this code is taken from the Ruby 2D beginner tuturial on Unity Learn which I spent many hours on, learning how it worked. 

public class GhostController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 3;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth; } }
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;
    bool show;
    float showTimer;

    public UILives hud;
    public DialogManager manager;
    public GameObject coinImage;
    public GameObject green;
    public AudioClip hit;

    Rigidbody2D rigidbody2d;

    private AudioSource audioSource;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        green.SetActive(false);
        isInvincible = true;
        invincibleTimer = timeInvincible;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

        position = position + move * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                green.SetActive(true);
            }
                

        }

        if (show)
        {
            showTimer -= Time.deltaTime;
            if (showTimer < 0)
            {
                show = false;
            }


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            manager.DisplayNextSentence();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            Debug.Log("x");
            if (hit.collider != null)
            {
                Debug.Log("y");
                WhosTalking character = hit.collider.GetComponent<WhosTalking>();
                if (character)
                {
                    character.startTalking();
                    Debug.Log("talk");
                }

                Portal portal = hit.collider.GetComponent<Portal>();
                if (portal!= null)
                {
                    portal.Transport();
                    show = false;
                    hud.CloseMessagePanel();
                    hud.CloseCoinPanel();

                }
            }

        }

        RaycastHit2D thud = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (thud.collider != null)
        {
            NonPlayerCharacter character = thud.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
            {
                hud.OpenMessagePanel();
                show = true;
            }

            Portal portal = thud.collider.GetComponent<Portal>();
            if (portal != null)
            {
                if (coinImage.activeSelf)
                {
                    hud.OpenMessagePanel();
                    show = true;
                }
                else
                {
                    hud.OpenCoinPanel();
                    show = true;
                }
                
            }
        }

        if (!show)
        {
            hud.CloseMessagePanel();
            hud.CloseCoinPanel();
        }


    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            animator.SetTrigger("Hit");
            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(hit);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UILives.instance.SetValue(currentHealth / (float)maxHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        UILives.instance.FadeToLevel();
    }

    public void ShowCoin()
    {
        coinImage.SetActive(true);
    }

    public void HideCoin()
    {
        coinImage.SetActive(false);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
