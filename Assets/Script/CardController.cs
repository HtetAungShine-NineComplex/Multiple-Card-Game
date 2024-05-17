using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    private bool firstGuess, secGuess;
    private int guessCount;
    private int guessCorrectCount;
    private int gameGuessCount;
    private int firstGuessIndex, secGuessIndex;
    private string firstGuessPuzzle, secGuessPuzzle;

    [SerializeField] private Sprite cardBG_2D;
    [SerializeField] private Sprite[] puzzles;
    [SerializeField] private List<Sprite> cardPuzzles = new List<Sprite>();
    [SerializeField] private Transform parent_TF;
    [SerializeField] private Button card_Btn;
    [SerializeField] private List<Button> cardBtns = new List<Button>();

    private int cardMaxVal;

    private void Awake()
    {
        cardMaxVal = GLOBALCONST.CARD_MAX_VALUE;
    }

    private void Start()
    {
        createCards();
        addCardPuzzles();
        ShuffleList(cardPuzzles);
        gameGuessCount = cardPuzzles.Count / 2;
    }

    private void createCards()
    {
        for(int i = 0; i < cardMaxVal; i++)
        {
            Button card = Instantiate(card_Btn);
            card.transform.SetParent(parent_TF);
            card.onClick.AddListener(() => ClickAPuzzle(card.GetComponent<Card>()));
            card.GetComponent<Card>().CardIndex = i;
            card.gameObject.name = GLOBALCONST.CARD_PREFAB_NAME + i;            
            card.GetComponent<Image>().sprite = cardBG_2D;
            cardBtns.Add(card);
        }
    }

    private void addCardPuzzles()
    {
        int looper = cardBtns.Count;
        int index = 0;

        for(int i = 0;i < looper;i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            cardPuzzles.Add(puzzles[index]);
            index++;
        }
    }

    public void ClickAPuzzle(Card card) //Card OnClick Event
    {
        int puzzleIndex = card.CardIndex;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = puzzleIndex;
            firstGuessPuzzle = cardPuzzles[firstGuessIndex].name;
            cardBtns[firstGuessIndex].image.sprite = cardPuzzles[firstGuessIndex];
        }
        else if (!secGuess)
        {
            secGuess = true;
            secGuessIndex = puzzleIndex;
            secGuessPuzzle = cardPuzzles[secGuessIndex].name;
            cardBtns[secGuessIndex].image.sprite = cardPuzzles[secGuessIndex];
            guessCount++;
            StartCoroutine(ICheckPuzzleMatch());
            
        }
    }

    IEnumerator ICheckPuzzleMatch()
    {
        yield return new WaitForSeconds(0.15f);
        

        if(firstGuessPuzzle == secGuessPuzzle && firstGuessIndex != secGuessIndex)
        {
            yield return new WaitForSeconds (0.2f);

            cardBtns[firstGuessIndex].interactable = false;
            cardBtns[secGuessIndex].interactable = false;
            cardBtns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            cardBtns[secGuessIndex].image.color = new Color(0, 0, 0, 0);

            checkGameFinish();
        }
        else
        {
            yield return new WaitForSeconds(0.2f);

            cardBtns[firstGuessIndex].image.sprite = cardBG_2D;
            cardBtns[secGuessIndex].image.sprite = cardBG_2D;
        }

        //yield return new WaitForSeconds(0.1f);

        firstGuess = false;
        secGuess = false;
    }

    void checkGameFinish()
    {
        guessCorrectCount++;

        if( guessCorrectCount == gameGuessCount)
        {
            Debug.Log("Game is finished");
            Debug.Log("It took you"+ guessCount + "to finish the game");
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
