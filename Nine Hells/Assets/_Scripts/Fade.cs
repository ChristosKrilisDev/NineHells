using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Character;
using DG.Tweening;
using UnityEngine;

public class Fade : MonoBehaviour
{

    public CanvasGroup CanvasGroup;
    public float fadeDuration = 0.5f;
    
    
    
    public static Fade Instance;
    
    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        FadeInAndOut();
    }

    public void FadeIn()
    {
        CanvasGroup.DOKill();
        PlayerController.CanMove = false;
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.interactable = true;
        CanvasGroup.DOFade(1,fadeDuration).OnComplete(() =>
        {

        });
    }


    public void FadeOut()
    {
        CanvasGroup.DOKill();
        CanvasGroup.DOFade(0,fadeDuration).SetEase(Ease.InExpo).OnComplete(()=>
        {
            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.interactable = false;
            PlayerController.CanMove = true;
        });
        
    }


    public void FadeInAndOut()
    {
        CanvasGroup.DOKill();
        PlayerController.CanMove = false;
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.interactable = true;

        
        CanvasGroup.DOFade(1,fadeDuration/6).OnComplete(() =>
        {

            FadeOut();
        });
        
    }
    
}
