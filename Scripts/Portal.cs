using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject image;
    private Transform player;
    public Vector3 location;
    public GhostController controller;
    public AudioClip collectedClip;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transport()
    {
        if (image.activeSelf)
        {
            player.position = new Vector3(location.x, location.y, location.z);
            controller.PlaySound(collectedClip);
            controller.HideCoin();
            Destroy(enemy);
        }
     }
}
