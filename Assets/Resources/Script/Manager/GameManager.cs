using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    [SerializeField] private CardManager cardManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PersistenceManager persistenceManager;
    [SerializeField] private SoundManager soundManager;

    private int firstGuessIndex = -1;
    private int secondGuessIndex = -1;
    private int correctGuessCount;
    private int totalGuessCount;
    private int gameGuessCount;
    private string firstGuessPuzzle, secGuessPuzzle;
    
    private bool firstGuess, secGuess;
    private int sameCardCount = 0;

    private void Awake()
    {
        correctGuessCount = persistenceManager.getCorrectGuessCount();
        totalGuessCount = persistenceManager.getGuesssCount();


        uiManager.UpdateCorrectGuessTxt(correctGuessCount);
        uiManager.UpdateTotalGuessTxt(totalGuessCount);
    }

    private void Start()
    {
        sameCardCount = persistenceManager.GetRecentSameCardCount();

        int maxCardValue = 8; // Set the desired maximum card value
        cardManager.CreateCards(maxCardValue, OnCardClick);;
        cardManager.AddCardPuzzles();
        GetOrShuffleCards();
        cardManager.ShowPuzzle();

        gameGuessCount = cardManager.GetCardPuzzles().Count / 2; //CardPuzzle2D List
        persistenceManager.setCards(cardManager.GetPuzzelSprites(), cardManager.GetCardPuzzles());
    }

    private void checkGameFinish()
    {
        correctGuessCount++;
        persistenceManager.setCorrectGuessCount(correctGuessCount);
        uiManager.UpdateCorrectGuessTxt(correctGuessCount);


        if (correctGuessCount == gameGuessCount)
        {
            soundManager.PlayGameFinishSound();
            uiManager.ShowGameCompletedUI();
            Debug.Log("Game is finished");
            Debug.Log("It took you " + totalGuessCount + " to finish the game");
            persistenceManager.clearGameData();
        }
    }

    private void GetOrShuffleCards()
    {
        if (PlayerPrefs.HasKey(GLOBALCONST.FIFTH_CARD_KEY))
        {
            persistenceManager.getCards(cardManager.GetCardPuzzles(), cardManager.GetPuzzelSprites());
            cardManager.removeRecentSameCards(persistenceManager.GetRecentSameCardIndexList());
        }
        else
        {
            Debug.Log("No cards found, shuffling cards");
            cardManager.ShuffleCards();
        }
    }

    private IEnumerator ICheckPuzzleMatch()
    {
        yield return new WaitForSeconds(0.15f);


        if (firstGuessPuzzle == secGuessPuzzle && firstGuessIndex != secondGuessIndex)
        {
            yield return new WaitForSeconds(0.2f);
            soundManager.PlayCardMatchSound();

            cardManager.removeSameCards(firstGuessIndex);
            cardManager.removeSameCards(secondGuessIndex);
            sameCardCount += 2;
            persistenceManager.setSameCards(sameCardCount, firstGuessIndex, secondGuessIndex);

            checkGameFinish();
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
            soundManager.PlayCardMisMatchSound();

            cardManager.ResetCardBackgroundByIndex(firstGuessIndex);
            cardManager.ResetCardBackgroundByIndex(secondGuessIndex);
        }

        //yield return new WaitForSeconds(0.3f);

        firstGuess = false;
        secGuess = false;
    }

    public void OnCardClick(Card card) //Card OnClick Event
    {
       soundManager.PlayCardFlipSound();

        int puzzleIndex = card.CardIndex;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = puzzleIndex;
            firstGuessPuzzle = cardManager.GetCardPuzzleByIndex(firstGuessIndex).name;
            cardManager.GetCardButtonByIndex(firstGuessIndex).image.sprite = cardManager.GetCardPuzzleByIndex(firstGuessIndex);
        }
        else if (!secGuess)
        {
            secGuess = true;
            secondGuessIndex = puzzleIndex;
            secGuessPuzzle = cardManager.GetCardPuzzleByIndex(secondGuessIndex).name;
            cardManager.GetCardButtonByIndex(secondGuessIndex).image.sprite = cardManager.GetCardPuzzleByIndex(secondGuessIndex);
            totalGuessCount++;
            persistenceManager.setGuessCount(totalGuessCount);
            totalGuessCount = persistenceManager.getGuesssCount();
            uiManager.UpdateTotalGuessTxt(totalGuessCount);

            StartCoroutine(ICheckPuzzleMatch());
        }
    }


}