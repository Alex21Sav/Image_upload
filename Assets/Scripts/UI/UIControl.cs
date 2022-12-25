using System;
using UnityEngine;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _bootSelection;
    public static event Action OnLoad;
    public static event Action OnCancel;
    public static event Action<LoadTypes> LoadType; 

    private void Start()
    {
        DropdownChoice(0);
    }
    public void DropdownChoice(int num)
    {
        switch (num)
        {
            case 0:
                LoadType?.Invoke(LoadTypes.AllAtOnce);
                break;
            case 1:
                LoadType?.Invoke(LoadTypes.OneByOne);
                break;
            case 2:
                LoadType?.Invoke(LoadTypes.WhenImageReady);
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
