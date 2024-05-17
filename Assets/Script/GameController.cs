using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Sprite cardBG_2D;
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
    }

    private void createCards()
    {
        for(int i = 0; i < cardMaxVal; i++)
        {
            Button card = Instantiate(card_Btn);
            card.gameObject.name = GLOBALCONST.CARD_PREFAB_NAME + i;
            card.transform.SetParent(parent_TF);
            card.GetComponent<Image>().sprite = cardBG_2D;
            cardBtns.Add(card);
        }
    }
}
