using System;
using UnityEngine;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _bootSelection;

    public static event Action AllAtOnce;
    public static event Action OneByOne;
    public static event Action WhenImageReady;
    public static event Action OnLoad;
    public static event Action OnCancel;

    public static event Action<LoadTypes> LoadType; 

    private void Start()
    {
        DropdownChoic(0);
    }
    public void DropdownChoic(int num)
    {
        switch (num)
        {
            case 0:
                LoadType?.Invoke(LoadTypes.AllAtOnce);
                Debug.Log("1");
                break;
            case 1:
                LoadType?.Invoke(LoadTypes.OneByOne);
                Debug.Log("2");
                break;
            case 2:
                LoadType?.Invoke(LoadTypes.WhenImageReady);
                Debug.Log("3");
                break;
        }
    }
    public void ButtonLoad()
    {
        OnLoad?.Invoke();
    }
    public void ButtonCancel()
    {
        OnCancel?.Invoke();
    }
    
    public enum LoadTypes
    {
        AllAtOnce,
        OneByOne,
        WhenImageReady
    }

}
