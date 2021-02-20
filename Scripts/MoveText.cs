using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveText : MonoBehaviour
{
    public GameObject words;
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 4.0f;
    // Update is called once per frame

    void Awake()
    {
        invincibleTimer = timeInvincible;
        isInvincible = true;
    }


    void Update()
    {

        transform.Translate(0, .02f, 0);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                SceneManager.LoadScene("SampleScene");
            }
                

        }

    }
}
