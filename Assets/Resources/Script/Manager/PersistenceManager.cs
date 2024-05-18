using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public void setCorrectGuessCount(int _guessCorrectCount)
    {
        PlayerPrefs.SetInt("CorrectGuessCount", _guessCorrectCount);
    }

    public int getCorrectGuessCount()
    {
        if (!PlayerPrefs.HasKey("CorrectGuessCount"))
        {
            PlayerPrefs.SetInt("CorrectGuessCount", 0);
        }

        return PlayerPrefs.GetInt("CorrectGuessCount");
    }

    public void setGuessCount(int guessCount)
    {
        PlayerPrefs.SetInt("GuessCount", guessCount);
    }

    public int getGuesssCount()
    {
        /*guessCount = PlayerPrefs.GetInt("GuessCount");
        playedTurns_Txt.text = guessCount.ToString();*/

        if (!PlayerPrefs.HasKey("GuessCount"))
        {
            PlayerPrefs.SetInt("GuessCount", 0);
        }

        return PlayerPrefs.GetInt("GuessCount");
    }

    public void setCards(List<Sprite> cardSprites, List<Sprite> shuffledSprites)
    {
        Debug.Log("Set Cards");

        for (int i = 0; i < shuffledSprites.Count; i++)
        {
            switch (i)
            {
                case 0:
                    PlayerPrefs.SetInt(GLOBALCONST.FIRST_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 1:
                    PlayerPrefs.SetInt(GLOBALCONST.SECOND_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 2:
                    PlayerPrefs.SetInt(GLOBALCONST.THIRD_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 3:
                    PlayerPrefs.SetInt(GLOBALCONST.FOURTH_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 4:
                    PlayerPrefs.SetInt(GLOBALCONST.FIFTH_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 5:
                    PlayerPrefs.SetInt(GLOBALCONST.SIXTH_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 6:
                    PlayerPrefs.SetInt(GLOBALCONST.SEVENTH_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                case 7:
                    PlayerPrefs.SetInt(GLOBALCONST.EIGHTH_CARD_KEY, cardSprites.IndexOf(shuffledSprites[i]));
                    break;

                default:
                    break;
            }
        }
    }

    public void getCards(List<Sprite> gameCardSprites, List<Sprite> cardSprites)
    {

        for (int i = 0; i < gameCardSprites.Count; i++)
        {
            switch (i)
            {
                case 0:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.FIRST_CARD_KEY)]);
                    break;

                case 1:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.SECOND_CARD_KEY)]);
                    break;

                case 2:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.THIRD_CARD_KEY)]);
                    break;

                case 3:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.FOURTH_CARD_KEY)]);
                    break;

                case 4:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.FIFTH_CARD_KEY)]);
                    break;

                case 5:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.SIXTH_CARD_KEY)]);
                    break;

                case 6:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.SEVENTH_CARD_KEY)]);
                    break;

                case 7:
                    gameCardSprites[i] = (cardSprites[PlayerPrefs.GetInt(GLOBALCONST.EIGHTH_CARD_KEY)]);
                    break;

                default:
                    break;
            }
        }
    }

    public List<int> GetRecentSameCardIndexList()
    {
        List<int> sameCardIndexList = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            switch (i)
            {
                case 0:
                    if (PlayerPrefs.HasKey(GLOBALCONST.FIRST_FLIP_CARD_KEY))
                    {
                        sameCardIndexList.Add(PlayerPrefs.GetInt(GLOBALCONST.FIRST_FLIP_CARD_KEY));
                    }
                    break;

                case 1:
                    if (PlayerPrefs.HasKey(GLOBALCONST.SECOND_FLIP_CARD_KEY))
                    {
                        sameCardIndexList.Add(PlayerPrefs.GetInt(GLOBALCONST.SECOND_FLIP_CARD_KEY));
                    }
                    break;
                case 2:
                    if (PlayerPrefs.HasKey(GLOBALCONST.THIRD_FLIP_CARD_KEY))
                    {
                        sameCardIndexList.Add(PlayerPrefs.GetInt(GLOBALCONST.THIRD_FLIP_CARD_KEY));
                    }
                    break;

                case 3:
                    if (PlayerPrefs.HasKey(GLOBALCONST.FOURTH_FLIP_CARD_KEY))
                    {
                        sameCardIndexList.Add(PlayerPrefs.GetInt(GLOBALCONST.FOURTH_FLIP_CARD_KEY));
                    }
                    break;

                case 4:
                    if (PlayerPrefs.HasKey(GLOBALCONST.FIFTH_FLIP_CARD_KEY))
                    {
                        sameCardIndexList.Add(PlayerPrefs.GetInt(GLOBALCONST.FIFTH_FLIP_CARD_KEY));
                    }
                    break;

                case 5:
                    if (PlayerPrefs.HasKey(GLOBALCONST.SIXTH_FLIP_CARD_KEY))
                    {
                        sameCardIndexList.Add(PlayerPrefs.GetInt(GLOBALCONST.SIXTH_FLIP_CARD_KEY));
                    }
                    break;

                default:
                    break;
            }

            
        }

        return sameCardIndexList;
    }

    public void setSameCards(int sameCardCount, int firstGuessIndex, int secGuessIndex)
    {
        PlayerPrefs.SetInt(GLOBALCONST.SAME_CARD_COUNT, sameCardCount);

        if (sameCardCount > 0)
        {
            if (sameCardCount == 2)
            {
                PlayerPrefs.SetInt(GLOBALCONST.FIRST_FLIP_CARD_KEY, firstGuessIndex);
                PlayerPrefs.SetInt(GLOBALCONST.SECOND_FLIP_CARD_KEY, secGuessIndex);
            }
            else if (sameCardCount == 4)
            {
                PlayerPrefs.SetInt(GLOBALCONST.THIRD_FLIP_CARD_KEY, firstGuessIndex);
                PlayerPrefs.SetInt(GLOBALCONST.FOURTH_FLIP_CARD_KEY, secGuessIndex);
            }
            else
            {
                PlayerPrefs.SetInt(GLOBALCONST.FIFTH_FLIP_CARD_KEY, firstGuessIndex);
                PlayerPrefs.SetInt(GLOBALCONST.SIXTH_FLIP_CARD_KEY, secGuessIndex);
            }
        }
    }

    public void clearGameData()
    {
        PlayerPrefs.DeleteAll();
    }

    public int GetRecentSameCardCount()
    {
        if (!PlayerPrefs.HasKey(GLOBALCONST.SAME_CARD_COUNT))
        {
            PlayerPrefs.SetInt(GLOBALCONST.SAME_CARD_COUNT, 0);
        }

        return PlayerPrefs.GetInt(GLOBALCONST.SAME_CARD_COUNT);
    }
}