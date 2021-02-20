using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
   public static Fader instance { get; private set; }



    Animator animator;



    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }




    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeCompleted()
    {
        SceneManager.LoadScene("EndGame");
    }


}
