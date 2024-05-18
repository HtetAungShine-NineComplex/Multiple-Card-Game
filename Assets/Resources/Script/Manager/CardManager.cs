using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Sprite cardBackgroundSprite;
    [SerializeField] private List<Sprite> puzzleSprites;
    [SerializeField] private Button cardButtonPrefab;
    [SerializeField] private Transform cardParentTransform;

    private List<Button> cardButtons = new List<Button>();
    private List<Sprite> cardPuzzles = new List<Sprite>();

    private float showPuzzleInterval = 1f;

    public List<Sprite> GetCardPuzzles()
    {
        return cardPuzzles;
    }

    public List<Sprite> GetPuzzelSprites()
    {
        return puzzleSprites;
    }

    public Sprite GetCardPuzzleByIndex(int index)
    {
        return cardPuzzles[index];
    }

    public Button GetCardButtonByIndex(int index)
    {
        return cardButtons[index];
    }

    public void CreateCards(int maxCardValue, Action<Card> onClickCard)
    {
        for (int i = 0; i < maxCardValue; i++)
        {
            Button card = Instantiate(cardButtonPrefab, cardParentTransform);
            card.GetComponent<Image>().sprite = cardBackgroundSprite;
            card.onClick.AddListener(() => onClickCard(card.GetComponent<Card>()));
            card.GetComponent<Card>().CardIndex = i;
            card.gameObject.name = GLOBALCONST.CARD_PREFAB_NAME + i;
            cardButtons.Add(card);
        }
    }

    public void AddCardPuzzles()
    {
        int looper = cardButtons.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            cardPuzzles.Add(puzzleSprites[index]);
            index++;
        }
    }

    public void ShowPuzzle()
    {
        StartCoroutine(IShowPuzzle());
    }

    IEnumerator IShowPuzzle()
    {
        for (int i = 0; i < cardButtons.Count; i++)
        {
            cardButtons[i].image.sprite = cardPuzzles[i];
            cardButtons[i].enabled = false;
        }

        yield return new WaitForSeconds(showPuzzleInterval);

        for (int i = 0; i < cardButtons.Count; i++)
        {
            cardButtons[i].image.sprite = cardBackgroundSprite;
            cardButtons[i].enabled = true;
        }
    }

    public void ShuffleCards()
    {
        ShuffleList(cardPuzzles);
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void SetCardsToButtons()
    {
        for (int i = 0; i < cardButtons.Count; i++)
        {
            cardButtons[i].GetComponent<Image>().sprite = cardPuzzles[i];
        }
    }

    public void removeRecentSameCards(List<int> removedCardIndexs)
    {

        for (int i = 0; i < removedCardIndexs.Count; i++)
        {
            removeSameCards(removedCardIndexs[i]);
        }
    }

    public void removeSameCards(int index)
    {
        cardButtons[index].interactable = false;
        cardButtons[index].image.color = new Color(0, 0, 0, 0);
    }

    public void ResetCardBackgroundByIndex(int index)
    {
        cardButtons[index].image.sprite = cardBackgroundSprite;
    }

    // Other card management methods...\

}