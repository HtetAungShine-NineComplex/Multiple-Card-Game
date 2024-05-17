using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
     private Button m_Btn;
    private void Awake()
    {
        m_Btn = GetComponent<Button>();
    }
    private void Start()
    {
        m_Btn.onClick.AddListener(OnClickMe);
    }

    private void OnClickMe()
    {
        Debug.Log(gameObject.name);
    }
}
