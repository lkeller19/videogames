using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //public float displayTime = 2.0f;
    public GameObject dialogBox;
    //public GameObject coinImage;
    //float timerDisplay;
    // Start is called before the first frame update
    /*  void Start()
      {
          coinImage.SetActive(false);
          timerDisplay = -1.0f;
      }

      // Update is called once per frame
      void Update()
      {
          if (timerDisplay >= 0)
          {
              timerDisplay -= Time.deltaTime;
              if (timerDisplay < 0)
              {
                  coinImage.SetActive(false);
              }
          }

      }
      */
    public GhostController controller;
    public AudioClip collectedClip;




    public void RemoveDialog()
    {
        dialogBox.SetActive(false);
        controller.PlaySound(collectedClip);
    }
/*
    public void ShowCoin()
    {
        coinImage.SetActive(true);
        timerDisplay = displayTime;
    }*/
}
