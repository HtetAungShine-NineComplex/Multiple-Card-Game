using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearLocalDataUI : MonoBehaviour
{
    [SerializeField] private Button clearLocalData_Btn;

    private void Awake()
    {
        clearLocalData_Btn.onClick.AddListener(() => onClickClearLocalData());
    }

    private void onClickClearLocalData()
    {
        PlayerPrefs.DeleteAll();
    }
}
