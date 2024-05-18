using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text correctGuessText;
    [SerializeField] private Text totalGuessText;
    [SerializeField] private GameObject gameCompletedUI;

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