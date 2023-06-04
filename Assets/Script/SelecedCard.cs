using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelecedCard : MonoBehaviour,IPointerClickHandler
{
    public Sprite[] CardCase;
    public Image CardCaseImg;
    public TMP_Text Ment;
    public TurnManager turnManager;
    public int CardNum;

    public int NewCardSelect()
    {
        int new_num = 0;
        while (true) {
            new_num = Random.Range(1, 23);
            if (new_num == 10)
            {
                new_num = 24;
            }
            bool is_new = true;
            for(int i = 0; i < turnManager.new_select.Count; i++)
            {
                if(new_num == turnManager.new_select[i])
                {
                    is_new = false;
                }
            }
            if (is_new == true)
            {
                break;
            }
        }
        return new_num;
    }

    public void colorSetting(int num)
    {
        if (0 <= num && 9 >= num)
        {
            CardCaseImg.sprite = CardCase[0];
        }
        else if (10 <= num && 19 >= num)
        {
            CardCaseImg.sprite = CardCase[1];
        }
        else if (20 <= num && 24 >= num)
        {
            CardCaseImg.sprite = CardCase[2];
        }
    }

    public void SetCard()
    {
        CardNum = NewCardSelect();
        colorSetting(CardNum);
        Ment.text = Config.Instance.CARD_MENT[CardNum];
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null)
        {
            Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.NEWCARD);
            turnManager.new_select.Add(CardNum);
            if (turnManager.new_select.Count == 3)
            {
                turnManager.BattleResult();
            }
            else
            {
                turnManager.set_newCard_select();
            }
        }
    }
}
