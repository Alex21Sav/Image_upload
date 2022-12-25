using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Scripts.UI;

public class ActivationCards : MonoBehaviour
{
    [SerializeField] private List<GetImages> _cards;
    [SerializeField] private GameObject _contentCards;
    private UIControl.LoadTypes _type;
    private int _sumIndexCards = 0;
    private int _indexwhenImageReady = 0;
    private bool _allAtOnce = false;
    private bool _oneByOne = false;
    private bool _whenImageReady = false;

    private void OnEnable()
    {
        UIControl.OnLoad += OnLoadCards;
        UIControl.OnCancel += OnCancelLoad;
        UIControl.LoadType += ChoicTypes;

        GetImages.EndGetImage += AddIndex;
    }
    private void OnDisable()
    {
        UIControl.OnLoad -= OnLoadCards;
        UIControl.OnCancel -= OnCancelLoad;
        UIControl.LoadType -= ChoicTypes;
        
        GetImages.EndGetImage -= AddIndex;
    }
    async void AddIndex(int index)
    {
        _sumIndexCards = _sumIndexCards + index;
        
        if (_sumIndexCards == 15 && _allAtOnce == true)
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].ActiveCard();
            }
            _sumIndexCards = 0;
        }
        if (_sumIndexCards == 15 && _oneByOne == true)
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].ActiveCard();
                await UniTask.Delay(200);
            }
            _sumIndexCards = 0;
        }
        if (_sumIndexCards <= 5 && _whenImageReady == true)
        {
            _indexwhenImageReady++;
            _sumIndexCards = _sumIndexCards - 1;
            _cards[_sumIndexCards].ActiveCard();
            _sumIndexCards = 0;
            if (_indexwhenImageReady == 5)
            {
                _sumIndexCards = 0;
            }
     
        }
    }
    private void ChoicTypes(UIControl.LoadTypes loadTypes)
    {
        OnCancelLoad();
        _type = loadTypes;
    }

    private void OnLoadCards()
    {
        switch (_type)
        {
            case UIControl.LoadTypes.AllAtOnce:
                _allAtOnce = true;
                _oneByOne = false;
                _whenImageReady = false;
                break;
            case UIControl.LoadTypes.OneByOne:
                _allAtOnce = false;
                _oneByOne = true;
                _whenImageReady = false;
                break;
            case UIControl.LoadTypes.WhenImageReady:
                _allAtOnce = false;
                _oneByOne = false;
                _whenImageReady = true;
                break;
        }
        _contentCards.SetActive(true);
    }
    
    
    private void OnCancelLoad()
    {
        _contentCards.SetActive(false);
        _allAtOnce = false;
        _oneByOne = false;
        _whenImageReady = false;
        _sumIndexCards = 0;
    }

}
