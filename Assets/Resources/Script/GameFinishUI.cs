using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFinishUI : MonoBehaviour
{
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button nextLevelBtn;

    private void Awake()
    {
        quitBtn.onClick.AddListener(() => OnCLickQuitBtn());
        nextLevelBtn.onClick.AddListener (()=> OnClickNextLevelBtn());
    }
    public void OnCLickQuitBtn()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void OnClickNextLevelBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GameScene");
    }
}
