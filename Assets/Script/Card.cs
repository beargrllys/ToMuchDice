using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using static Config;

public class Card : MonoBehaviour
{
    public Ally m_ally;
    public Enemy m_enemy;
    public DiceDeque m_dice;
    public CardDeque m_card;

    public TMP_Text TMP_DiceVal;
    public TMP_Text TMP_CardMent;

    public int DiceVal;
    public bool isUsed = false;

    public int CardIDX;
    public int m_CardCode;
    private string Card_ment;

    private void Start()
    {
        m_ally = GameObject.FindGameObjectWithTag("ALLY").GetComponent<Ally>();
        m_enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
        m_card = GameObject.FindGameObjectWithTag("CARD").GetComponent<CardDeque>();
        init_setting(0);
    }

    public void init_setting(int card_Code)
    {
        isUsed = false;
        m_CardCode = card_Code;
        string str = card_ret(false, DiceVal);
        Card_ment = str;
        TMP_CardMent.text = str;
    }

    public void click_card(bool is_click, bool is_realUse = false)
    {
        if (is_click)
        {
            DiceVal = m_dice.Get_Dice();
            TMP_DiceVal.text = DiceVal.ToString();
            string str = card_ret(true, DiceVal, is_realUse);
            Debug.Log(str);
            Card_ment = str;
            TMP_CardMent.text = str;
        }
        else
        {
            TMP_DiceVal.text = "?";
            string str = card_ret(false, DiceVal);
            Card_ment = str;
            TMP_CardMent.text = str;
        }
    }

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
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged(dice * 2);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 2).ToString());
        }
        else
        {
            return string.Format(
                    Config.Instance.CARD_MENT[m_CardCode],
                    "N×2");
        }
    }
    string ATK2(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                StartCoroutine(ATK2_action(dice));
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice).ToString());
        }
        else
        {
            return string.Format(
                    Config.Instance.CARD_MENT[m_CardCode],
                    "N");
        }
    }

    IEnumerator ATK2_action(int dice)
    {
        for (int i = 0; i < dice; i++)
        {
            m_enemy.Get_Damaged(2);
            yield return new WaitForSeconds(0.2f);
        }
    }

    string ATK3(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged(12 - (dice * 2));
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (12 - (dice * 2)).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "12-N×2");
    }
    string ATK4(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged(8);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (8).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "8");
    }
    string ATK5(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged((-10)* dice);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                ((-10) * dice).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N×(-10)");
    }

    string ATK6(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged((dice + 2) * 2);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                ((dice+2)*2).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "(N+2)×2");
    }
    string ATK7(bool read, int dice1, bool Attack)
    {
        int dice2 = m_dice.Get_Dice(1);
        int dice3 = m_dice.Get_Dice(2);
        //주사위 3개사용
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged(dice1 + dice2 + dice3);
                for (int i = 0; i < 3; i++)
                {
                    m_dice.Use_Dice();
                }
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice1 + dice2 + dice3).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string ATK8(bool read, int dice, bool Attack)
    {
        int handCard = m_card.m_Display_Deque.Count;
        if (read)
        {
            if (Attack)
            {
                m_enemy.Get_Damaged(handCard * dice);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (handCard * dice).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string ATK9(bool read, int dice, bool Attack)
    {
        int handCard = m_card.m_Display_Deque.Count;
        int dmg = 0;
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
                m_enemy.Get_Damaged(dmg);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                dmg);
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string ATK10(bool read, int dice, bool Attack)
    {
        if (read)
        {
            if (Attack)
            {
                for (int i = 0; i < dice; i++)
                {
                    m_enemy.Get_Damaged(dice);
                }
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * dice).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
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
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 2).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string DPN2(bool read, int dice, bool Defense)
    {
        //추후조정
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice * 3);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 3).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
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
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (def).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string DPN4(bool read, int dice, bool Defense)
    {
        int def = 0;
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
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (def).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
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
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (def).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }

    string DPN6(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice * 2);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 2).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string DPN7(bool read, int dice, bool Defense)
    {
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Damaged(5);
                m_ally.Get_Shield(dice * 4);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 4).ToString(), "5");
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N", "5");
    }
    string DPN8(bool read, int dice, bool Defense)
    {
        //N Def, 만약 방어 후 방어도가 남아있으면 그 수치 그대로 공격으로 전환 
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice * 2);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string DPN9(bool read, int dice, bool Defense)
    {
        //(M=사용한 카드 수) N*(8-M) 
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice * 2);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 2).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }
    string DPN10(bool read, int dice, bool Defense)
    {
        //70 Def, M=0일때만 사용 가능, 사용 시 모든 패를 버림 
        if (read)
        {
            if (Defense)
            {
                m_ally.Get_Shield(dice * 2);
                m_dice.Use_Dice();
            }
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 2).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "N");
    }


    string SKIL1(bool read, int dice, bool Defense)
    {
        return dice.ToString();
    }
    string SKIL2(bool read, int dice, bool Defense)
    {
        return dice.ToString();
    }
    string SKIL3(bool read, int dice, bool Defense)
    {
        return dice.ToString();
    }
    string SKIL4(bool read, int dice, bool Defense)
    {
        return dice.ToString();
    }
    string SKIL5(bool read, int dice, bool Defense)
    {
        return dice.ToString();
    }
}
