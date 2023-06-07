using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using static Config;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Ally m_ally;
    public DiceDeque m_dice;
    public CardDeque m_card;
    public InputSystem inputSystem;

    public TMP_Text TMP_DiceVal;
    public TMP_Text TMP_CardMent;

    public Sprite[] CardCase;
    public Image CardCaseImg;

    public int DiceVal;
    public bool isUsed = false;

    public int CardIDX;
    public int m_CardCode;
    private string Card_ment;

    //---------------------------특수기믹-------------------
    public bool DPN10_flag;

    private void Start()
    {
        m_ally = GameObject.FindGameObjectWithTag("ALLY").GetComponent<Ally>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
        m_card = GameObject.FindGameObjectWithTag("CARD").GetComponent<CardDeque>();
        init_setting(0);
    }
    //카드 초기화
    public void init_setting(int card_Code)
    {
        isUsed = false;
        m_CardCode = card_Code;
        colorSetting();
        string str = card_ret(false, DiceVal);
        TMP_DiceVal.text = "?";
        Card_ment = Config.Instance.CARD_TITLE[m_CardCode];
        TMP_CardMent.text = Config.Instance.CARD_TITLE[m_CardCode];
    }
    // 카드 속성시 배경 설정
    public void colorSetting()
    {
        if(0 <= m_CardCode && 9 >= m_CardCode)
        {
            CardCaseImg.sprite = CardCase[0];
        }
        else if (10 <= m_CardCode && 19 >= m_CardCode)
        {
            CardCaseImg.sprite = CardCase[1];
        }
        else if (20 <= m_CardCode && 24 >= m_CardCode)
        {
            CardCaseImg.sprite = CardCase[2];
        }
    }
    //마우스 On 시 계산값 업데이트
    public void click_card(bool is_click, bool is_realUse = false)
    {
        if (is_click)
        {
            DiceVal = m_dice.Get_Dice();
            string Val = card_ret(true, DiceVal, is_realUse);
            TMP_DiceVal.text = Val;
            Card_ment = Config.Instance.CARD_MENT[m_CardCode];
            TMP_CardMent.text = Config.Instance.CARD_MENT[m_CardCode];
        }
        else
        {
            TMP_DiceVal.text = "?";
            string str = card_ret(false, DiceVal);
            Card_ment = Config.Instance.CARD_TITLE[m_CardCode];
            TMP_CardMent.text = Config.Instance.CARD_TITLE[m_CardCode];
        }
    }
    //카드 스킬 문구 
    string card_ret(bool is_click, int dice, bool is_realUse = false)
    {
        string str = "";

        switch (m_CardCode)
        {
            case (int)CARD_VAL.ATK1:
                str = ATK1(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK2:
                str = ATK2(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK3:
                str = ATK3(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK4:
                str = ATK4(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK5:
                str = ATK5(is_click, dice, is_realUse);
                break;


            case (int)CARD_VAL.ATK6:
                str = ATK6(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK7:
                str = ATK7(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK8:
                str = ATK8(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK9:
                str = ATK9(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.ATK10:
                str = ATK10(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN1:
                str = DPN1(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN2:
                str = DPN2(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN3:
                str = DPN3(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN4:
                str = DPN4(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN5:
                str = DPN5(is_click, dice, is_realUse);
                break;


            case (int)CARD_VAL.DPN6:
                str = DPN6(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN7:
                str = DPN7(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN8:
                str = DPN8(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN9:
                str = DPN9(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.DPN10:
                str = DPN10(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.SKIL1:
                str = SKIL1(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.SKIL2:
                str = SKIL2(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.SKIL3:
                str = SKIL3(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.SKIL4:
                str = SKIL4(is_click, dice, is_realUse);
                break;

            case (int)CARD_VAL.SKIL5:
                str = SKIL5(is_click, dice, is_realUse);
                break;

            default:
                break;
        }

        return str;
    }

    string ATK1(bool read, int dice, bool Attack)
    {
        int ret = dice * 2;
        ret += m_card.SKIL2_power;
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(ret);
                m_dice.Use_Dice();
            }
        }
        return (ret).ToString();
    }
    string ATK2(bool read, int dice, bool Attack)
    {
        int ret = dice * (2+ m_card.SKIL2_power);
        if (read)
        {
            if (Attack)
            {
                StartCoroutine(ATK2_action(dice));
                m_dice.Use_Dice();
            }
        }
        return (ret).ToString();
    }

    IEnumerator ATK2_action(int dice)
    {
        for (int i = 0; i < dice; i++)
        {
            m_ally.Accamulate_Deal(2+m_card.SKIL2_power);
            yield return new WaitForSeconds(0.5f);
        }
    }

    string ATK3(bool read, int dice, bool Attack)
    {
        int ret = (12 - (dice * 2) + m_card.SKIL2_power);
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(ret);
                m_dice.Use_Dice();
            }
        }
        return (ret).ToString();
    }
    string ATK4(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(8 + m_card.SKIL2_power);
                m_dice.Use_Dice();
            }
        }
        return (8 + m_card.SKIL2_power).ToString();
    }
    string ATK5(bool read, int dice, bool Attack)
    {
        int ret = (((-10) * dice) + m_card.SKIL2_power);
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(ret);
                m_dice.Use_Dice();
            }
        }
        return (ret).ToString();
    }

    string ATK6(bool read, int dice, bool Attack)
    {
        int ret = (((dice + 2) * 2) + m_card.SKIL2_power);
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(ret);
                m_dice.Use_Dice();
                m_dice.Use_Dice();
            }
        }
        return (ret).ToString();
    }
    string ATK7(bool read, int dice1, bool Attack)
    {
        int dice2 = m_dice.Get_Dice(1);
        int dice3 = m_dice.Get_Dice(2);
        int ret = ((dice1 + dice2 + dice3) + m_card.SKIL2_power);
        //주사위 3개사용
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(ret);
                for (int i = 0; i < 3; i++)
                {
                    m_dice.Use_Dice();
                }
            }
        }
        return (ret).ToString();
    }
    string ATK8(bool read, int dice, bool Attack)
    {
        int handCard = m_card.m_Display_Deque.Count;
        int ret = ((handCard * dice) + m_card.SKIL2_power);
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(ret);
                m_dice.Use_Dice();
            }
        }
        return (ret).ToString();
    }
    string ATK9(bool read, int dice, bool Attack)
    {
        int handCard = m_card.m_Display_Deque.Count;
        int dmg;
        if (handCard == 1)
        {
            dmg = dice * 7;
        }
        else
        {
            dmg = dice;
        }
        if (read)
        {
            if (Attack)
            {
                m_ally.Accamulate_Deal(dmg + m_card.SKIL2_power);
                m_dice.Use_Dice();
            }
        }
        return (dmg + m_card.SKIL2_power).ToString();
    }
    string ATK10(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                StartCoroutine(ATK10_action(dice));
                m_dice.Use_Dice();
            }
        }
        return (dice * (dice + m_card.SKIL2_power)).ToString();
    }
    IEnumerator ATK10_action(int dice)
    {
        for (int i = 0; i < dice; i++)
        {
            m_ally.Accamulate_Deal(dice + m_card.SKIL2_power);
            yield return new WaitForSeconds(0.5f);
        }
    }


    string DPN1(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice*2);
                m_dice.Use_Dice();
            }
        }
        return (dice * 2).ToString();
    }
    string DPN2(bool read, int dice, bool Defense)
    {
        //추후조정
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice * 3);
                m_card.Drop_Last_Card();
                m_dice.Use_Dice();
            }
        }
        return (dice * 3).ToString();
    }
    string DPN3(bool read, int dice, bool Defense)
    {
        int def = 10;
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(def);
                m_dice.Use_Dice();
            }
        }
        return (def).ToString();
    }
    string DPN4(bool read, int dice, bool Defense)
    {
        int def;
        if(dice % 2 == 1)
        {
            def = dice * 3;
        }
        else
        {
            def = dice;
        }
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(def);
                m_dice.Use_Dice();
            }
        }
        return (def).ToString();
    }
    string DPN5(bool read, int dice, bool Defense)
    {
        int def = dice*(-15);

        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(def);
                m_dice.Use_Dice();
            }
        }
        return (def).ToString();
    }

    string DPN6(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                StartCoroutine(DPN6_action(dice));
                m_dice.Use_Dice();
            }
        }
        return (dice*dice).ToString();
    }

    IEnumerator DPN6_action(int dice)
    {
        for (int i = 0; i < dice; i++)
        {
            m_ally.Get_Shield(dice * 2);
            yield return new WaitForSeconds(0.5f);
        }
    }
    string DPN7(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                StartCoroutine (DPN7_action(dice));
                m_dice.Use_Dice();
            }
        }
        return (dice * 4).ToString();
    }
    IEnumerator DPN7_action(int dice)
    {
        m_ally.Get_Damaged(5);
        yield return new WaitForSeconds(0.5f);
        m_ally.Get_Shield(dice * 4);
        yield return new WaitForSeconds(0.5f);
    }
    string DPN8(bool read, int dice, bool Defense)
    {
        //N Def, 만약 방어 후 방어도가 남아있으면 그 수치 그대로 공격으로 전환 
        if (read)
        {
            if (Defense)
            {
                m_ally.DPN8_flag = true;
                m_ally.Get_Shield(dice);
                m_dice.Use_Dice();
            }
        }
        return (dice).ToString();
    }
    string DPN9(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice);
                m_dice.Use_Dice();
            }
        }
        return (dice).ToString();
    }
    string DPN10(bool read, int dice, bool Defense)
    {
        //70 Def, M=0일때만 사용 가능, 사용 시 모든 패를 버림 
        if (read)
        {
            if (Defense)
            {
                if(m_ally.Get_UsedCard_cnt() == 0)
                {
                    m_ally.Get_Shield(70);
                    m_card.Drop_All_Card(CardIDX);
                    m_dice.Use_Dice();
                }
                else
                {
                    DPN10_flag = true;
                    inputSystem.Get_Back();
                }
            }
        }
        return (dice).ToString();
    }


    string SKIL1(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                int cnt = m_card.getDisplayCnt();
                m_card.Drop_All_Card(CardIDX);
                m_card.Draw_Card(cnt);
                m_card.ChangeAllDice();
            }
        }
        return "!";
    }
    string SKIL2(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_card.SKIL2_power = 2;
            }
        }
        return "!";
    }
    string SKIL3(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_card.NextDiceInc();
            }
        }
        return "!";
    }
    string SKIL4(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_card.Drop_Last_Card();
                m_card.Draw_Card(2);
            }
        }
        return "!";
    }
    string SKIL5(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_card.NextDiceRed();
            }
        }
        return "!";
    }
}
