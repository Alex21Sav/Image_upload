using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [SerializeField] private CanvasGroup _cardImage;
    [SerializeField] private RectTransform _scaleImage;
    private Tweener _tweener;

    private void OnEnable()
    {
        _tweener.Kill();
    }
    public void StartAnimatiom()
    {
        _cardImage.alpha = 0;
        _scaleImage.localScale = new Vector3(0,0 ,0); 
        _tweener = _scaleImage.DOScale(1, 1);
        _tweener = _cardImage.DOFade(1, 2);
    } 
    
}
