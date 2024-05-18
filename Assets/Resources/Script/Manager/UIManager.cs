using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private Text correctGuessText;
    [SerializeField] private Text totalGuessText;
    [SerializeField] private GameObject gameCompletedUI;
    #endregion

    public void UpdateCorrectGuessTxt(int correctGuessCount)
    {
        correctGuessText.text = correctGuessCount.ToString();
    }

    public void UpdateTotalGuessTxt(int totalGuessCount)
    {
        totalGuessText.text = totalGuessCount.ToString();
    }

    public void ShowGameCompletedUI()
    {
        gameCompletedUI.SetActive(true);
    }
}