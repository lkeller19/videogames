using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Socket : MonoBehaviour
{
    public Fader fade;
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GhostController player = other.gameObject.GetComponent<GhostController>();

        if (player != null)
        {
            image.SetActive(true);
            fade.FadeToLevel();
        }
    }
}
