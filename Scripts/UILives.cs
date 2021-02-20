using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILives : MonoBehaviour
{
    public static UILives instance { get; private set; }

    public Image mask;
    float originalSize;

    Animator animator;

    public GameObject MessagePanel;
    public GameObject FindCoin;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        animator = GetComponent<Animator>();
    }


    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMessagePanel()
    {
        MessagePanel.SetActive(true);
    }

    public void OpenCoinPanel()
    {
        FindCoin.SetActive(true);
    }

    public void CloseCoinPanel()
    {
        FindCoin.SetActive(false);
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }


}
