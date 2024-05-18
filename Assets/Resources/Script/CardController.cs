using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    #region field

    private int guessCount;
    private int guessCorrectCount;
    private int gameGuessCount;
    private int firstGuessIndex, secGuessIndex;
    private int cardMaxVal;
    private string firstGuessPuzzle, secGuessPuzzle;
    private float showPuzzleInterval;
    private bool firstGuess, secGuess;
    private int sameCardCount = 0;

    [Header("Sprite")]
    [SerializeField] private Sprite cardBG_2D;
    [SerializeField] private List<Sprite> puzzles_2D;
    [SerializeField] private List<Sprite> cardPuzzles_2D = new List<Sprite>();

    [Header("Transform")]
    [SerializeField] private Transform parent_TF;

    [Header("Button")]
    [SerializeField] private Button card_Btn;
    [SerializeField] private List<Button> cardBtns = new List<Button>();

    [Header("Text")]
    [SerializeField] private Text correctGuess_Txt;
    [SerializeField] private Text playedTurns_Txt;

    [SerializeField] private GameObject gameFinishUI;
    #endregion

    #region unity events
    void Awake()
    {
        cardMaxVal = GLOBALCONST.CARD_MAX_VALUE;
        showPuzzleInterval = GLOBALCONST.SHOW_PUZZLE_INTERVAL;

        getCorrectGuessCount();
        getGuesssCount();
    }

    void Start()
    {
        setRecentSameCardCount();
        createCards();
        addCardPuzzles();
        GetOrShuffleCards();
        StartCoroutine(IShowPuzzle());
        gameGuessCount = cardPuzzles_2D.Count / 2;
        setCards(cardPuzzles_2D);
    }

    private void setRecentSameCardCount()
    {
        if (PlayerPrefs.HasKey(GLOBALCONST.SAME_CARD_COUNT))
        {
            sameCardCount = PlayerPrefs.GetInt(GLOBALCONST.SAME_CARD_COUNT);
        }
        else
        {
            sameCardCount = 0;
        }

        Debug.Log(sameCardCount);
    }

    private void GetOrShuffleCards()
    {
        if (PlayerPrefs.HasKey(GLOBALCONST.FIFTH_CARD_KEY))
        {
            getCards();
        }
        else
        {
            ShuffleList(cardPuzzles_2D);
        }
    }

    #endregion

    #region private methods
    private void createCards()
    {
        for (int i = 0; i < cardMaxVal; i++)
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

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            cardPuzzles_2D.Add(puzzles_2D[index]);
            index++;
        }
    }

    private void checkGameFinish()
    {
        guessCorrectCount++;
        setCorrectGuessCount(guessCorrectCount);
        getCorrectGuessCount();


        if (guessCorrectCount == gameGuessCount)
        {
            SoundManager.Instance.PlayGameFinishSound();
            gameFinishUI.gameObject.SetActive(true);
            Debug.Log("Game is finished");
            Debug.Log("It took you " + guessCount + " to finish the game");
        }
    }

    #region Save_Load
    private void setCorrectGuessCount(int _guessCorrectCount)
    {
        PlayerPrefs.SetInt("CorrectGuessCount", _guessCorrectCount);
    }
    private void getCorrectGuessCount()
    {
        //PlayerPrefs.GetInt("CorrectGuessCount");
        guessCorrectCount = PlayerPrefs.GetInt("CorrectGuessCount");
        correctGuess_Txt.text = guessCorrectCount.ToString();
    }

    private void setGuessCount(int _guessCount)
    {
        PlayerPrefs.SetInt("GuessCount", _guessCount);
    }

    private void getGuesssCount()
    {
        guessCount = PlayerPrefs.GetInt("GuessCount");
        playedTurns_Txt.text = guessCount.ToString();
    }

    private void setCards(List<Sprite> sprites)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            switch (i)
            {
                case 0:
                    PlayerPrefs.SetInt(GLOBALCONST.FIRST_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 1:
                    PlayerPrefs.SetInt(GLOBALCONST.SECOND_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 2:
                    PlayerPrefs.SetInt(GLOBALCONST.THIRD_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 3:
                    PlayerPrefs.SetInt(GLOBALCONST.FOURTH_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 4:
                    PlayerPrefs.SetInt(GLOBALCONST.FIFTH_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 5:
                    PlayerPrefs.SetInt(GLOBALCONST.SIXTH_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 6:
                    PlayerPrefs.SetInt(GLOBALCONST.SEVENTH_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                case 7:
                    PlayerPrefs.SetInt(GLOBALCONST.EIGHTH_CARD_KEY, puzzles_2D.IndexOf(sprites[i]));
                    break;

                default:
                    break;
            }
        }
    }

    private List<Sprite> getCards()
    {
        List<Sprite> cards = new List<Sprite>();




        for (int i = 0; i < cardPuzzles_2D.Count; i++)
        {
            switch (i)
            {
                case 0:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.FIRST_CARD_KEY)]);
                    break;

                case 1:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.SECOND_CARD_KEY)]);
                    break;

                case 2:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.THIRD_CARD_KEY)]);
                    break;

                case 3:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.FOURTH_CARD_KEY)]);
                    break;

                case 4:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.FIFTH_CARD_KEY)]);
                    break;

                case 5:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.SIXTH_CARD_KEY)]);
                    break;

                case 6:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.SEVENTH_CARD_KEY)]);
                    break;

                case 7:
                    cardPuzzles_2D[i] = (puzzles_2D[PlayerPrefs.GetInt(GLOBALCONST.EIGHTH_CARD_KEY)]);
                    break;

                default:
                    break;
            }
        }

        removeRecentSameCards();

        return cards;
    }

    private void setSameCards()
    {
        PlayerPrefs.SetInt(GLOBALCONST.SAME_CARD_COUNT, sameCardCount);

        if (sameCardCount > 0)
        {
            if (sameCardCount == 2)
            {
                PlayerPrefs.SetInt(GLOBALCONST.FIRST_FLIP_CARD, firstGuessIndex);
                PlayerPrefs.SetInt(GLOBALCONST.SECOND_FLIP_CARD, secGuessIndex);
            }
            else if (sameCardCount == 4)
            {
                PlayerPrefs.SetInt(GLOBALCONST.THIRD_FLIP_CARD, firstGuessIndex);
                PlayerPrefs.SetInt(GLOBALCONST.FOURTH_FLIP_CARD, secGuessIndex);
            }
            else
            {
                PlayerPrefs.SetInt(GLOBALCONST.FIFTH_FLIP_CARD, firstGuessIndex);
                PlayerPrefs.SetInt(GLOBALCONST.SIXTH_FLIP_CARD, secGuessIndex);
            }
        }
    }

    private void removeRecentSameCards()
    {
        for (int i = 0; i < 6; i++)
        {
            switch (i)
            {
                case 0:
                    if (PlayerPrefs.HasKey(GLOBALCONST.FIRST_FLIP_CARD))
                    {
                        removeSameCards(PlayerPrefs.GetInt(GLOBALCONST.FIRST_FLIP_CARD));
                    }
                    break;

                case 1:
                    if (PlayerPrefs.HasKey(GLOBALCONST.SECOND_FLIP_CARD))
                    {
                        removeSameCards(PlayerPrefs.GetInt(GLOBALCONST.SECOND_FLIP_CARD));
                    }
                    break;
                case 2:
                    if (PlayerPrefs.HasKey(GLOBALCONST.THIRD_FLIP_CARD))
                    {
                        removeSameCards(PlayerPrefs.GetInt(GLOBALCONST.THIRD_FLIP_CARD));
                    }
                    break;

                case 3:
                    if (PlayerPrefs.HasKey(GLOBALCONST.FOURTH_FLIP_CARD))
                    {
                        removeSameCards(PlayerPrefs.GetInt(GLOBALCONST.FOURTH_FLIP_CARD));
                    }
                    break;

                case 4:
                    if (PlayerPrefs.HasKey(GLOBALCONST.FIFTH_FLIP_CARD))
                    {
                        removeSameCards(PlayerPrefs.GetInt(GLOBALCONST.FIFTH_FLIP_CARD));
                    }
                    break;

                case 5:
                    if (PlayerPrefs.HasKey(GLOBALCONST.SIXTH_FLIP_CARD))
                    {
                        removeSameCards(PlayerPrefs.GetInt(GLOBALCONST.SIXTH_FLIP_CARD));
                    }
                    break;

                default:
                    break;
            }
        }


    }

    #endregion

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

    #endregion

    #region public methods
    public void ClickAPuzzle(Card card) //Card OnClick Event
    {
        SoundManager.Instance.PlayCardFlipSound();

        int puzzleIndex = card.CardIndex;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = puzzleIndex;
            firstGuessPuzzle = cardPuzzles_2D[firstGuessIndex].name;
            cardBtns[firstGuessIndex].image.sprite = cardPuzzles_2D[firstGuessIndex];
        }
        else if (!secGuess)
        {
            secGuess = true;
            secGuessIndex = puzzleIndex;
            secGuessPuzzle = cardPuzzles_2D[secGuessIndex].name;
            cardBtns[secGuessIndex].image.sprite = cardPuzzles_2D[secGuessIndex];
            guessCount++;
            setGuessCount(guessCount);
            getGuesssCount();

            StartCoroutine(ICheckPuzzleMatch());
        }
    }
    #endregion

    #region coroutine

    IEnumerator IShowPuzzle()
    {
        for (int i = 0; i < cardBtns.Count; i++)
        {
            cardBtns[i].image.sprite = cardPuzzles_2D[i];
            cardBtns[i].enabled = false;
        }

        yield return new WaitForSeconds(showPuzzleInterval);

        for (int i = 0; i < cardBtns.Count; i++)
        {
            cardBtns[i].image.sprite = cardBG_2D;
            cardBtns[i].enabled = true;
        }

        //yield return new WaitForSeconds(0.5f);
    }
    IEnumerator ICheckPuzzleMatch()
    {
        yield return new WaitForSeconds(0.15f);


        if (firstGuessPuzzle == secGuessPuzzle && firstGuessIndex != secGuessIndex)
        {
            yield return new WaitForSeconds(0.2f);
            SoundManager.Instance.PlayCardMatchSound();

            removeSameCards(firstGuessIndex);
            removeSameCards(secGuessIndex);
            sameCardCount += 2;
            setSameCards();

            checkGameFinish();
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
            SoundManager.Instance.PlayCardMisMatchSound();

            cardBtns[firstGuessIndex].image.sprite = cardBG_2D;
            cardBtns[secGuessIndex].image.sprite = cardBG_2D;
        }

        //yield return new WaitForSeconds(0.3f);

        firstGuess = false;
        secGuess = false;
    }

    private void removeSameCards(int index)
    {
        cardBtns[index].interactable = false;
        cardBtns[index].image.color = new Color(0, 0, 0, 0);
    }

    #endregion
}
