using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopIn : MonoBehaviour
{
    public float displayTime = 3.0f;
    public GameObject self;
    //public GameObject coinImage;
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        self.SetActive(false);
        timerDisplay = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                self.SetActive(true);

            }
        }

    }
}
