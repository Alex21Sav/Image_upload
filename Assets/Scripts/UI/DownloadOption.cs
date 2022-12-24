using System;
using UnityEngine;
using TMPro;

public class DownloadOption : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _bootSelection;

    public static event Action AllAtOnce;
    public static event Action OneByOne;
    public static event Action WhenImageReady;

    private void Start()
    {
        DropdownChoic(0);
    }
    public void DropdownChoic(int num)
    {
        switch (num)
        {
            case 0:
                AllAtOnce?.Invoke();
                Debug.Log("1");
                break;
            case 1:
                OneByOne?.Invoke();
                Debug.Log("2");
                break;
            case 2:
                WhenImageReady?.Invoke();
                Debug.Log("3");
                break;
        }
    }
}
