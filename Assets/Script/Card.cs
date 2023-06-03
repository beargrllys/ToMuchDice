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

    public TMP_Text TMP_DiceVal;
    public TMP_Text TMP_CardMent;

    public int DiceVal;
    public bool isUsed = false;

    public int CardIDX;
    private int m_CardCode;
    private string Card_ment;

    private void Start()
    {
        m_ally = GameObject.FindGameObjectWithTag("ALLY").GetComponent<Ally>();
        m_enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
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

    public void click_card(bool is_click)
    {
        if (is_click)
        {
            DiceVal = m_dice.Get_Dice();
            TMP_DiceVal.text = DiceVal.ToString();
            string str = card_ret(true, DiceVal);
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

    string card_ret(bool is_click, int dice)
    {
        string str = "";

        switch (m_CardCode)
        {
            case (int)CARD_VAL.ATK1:
                str = ATK1(is_click, dice);
                break;

            case (int)CARD_VAL.ATK2:
                ATK2(dice);
                break;

            case (int)CARD_VAL.ATK3:
                str = ATK3(is_click, dice);
                break;

            case (int)CARD_VAL.ATK4:
                ATK4(dice);
                break;

            case (int)CARD_VAL.ATK5:
                ATK5(dice);
                break;


            case (int)CARD_VAL.ATK6:
                ATK6(dice);
                break;

            case (int)CARD_VAL.ATK7:
                ATK7(dice);
                break;

            case (int)CARD_VAL.ATK8:
                ATK8(dice);
                break;

            case (int)CARD_VAL.ATK9:
                ATK9(dice);
                break;

            case (int)CARD_VAL.ATK10:
                ATK10(dice);
                break;

            case (int)CARD_VAL.DPN1:
                DPN1(dice);
                break;

            case (int)CARD_VAL.DPN2:
                DPN2(dice);
                break;

            case (int)CARD_VAL.DPN3:
                DPN3(dice);
                break;

            case (int)CARD_VAL.DPN4:
                DPN4(dice);
                break;

            case (int)CARD_VAL.DPN5:
                DPN5(dice);
                break;


            case (int)CARD_VAL.DPN6:
                DPN6(dice);
                break;

            case (int)CARD_VAL.DPN7:
                DPN7(dice);
                break;

            case (int)CARD_VAL.DPN8:
                DPN8(dice);
                break;

            case (int)CARD_VAL.DPN9:
                DPN9(dice);
                break;

            case (int)CARD_VAL.DPN10:
                DPN10(dice);
                break;

            case (int)CARD_VAL.SKIL1:
                SKIL1(dice);
                break;

            case (int)CARD_VAL.SKIL2:
                SKIL2(dice);
                break;

            case (int)CARD_VAL.SKIL3:
                SKIL3(dice);
                break;

            case (int)CARD_VAL.SKIL4:
                SKIL4(dice);
                break;

            case (int)CARD_VAL.SKIL5:
                SKIL5(dice);
                break;

            default:
                break;
        }

        return str;
    }

    string ATK1(bool read, int dice)
    {
        Debug.Log(read);
        if (read)
        {
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (dice * 2).ToString());
        }
        else
        {
            return string.Format(
                    Config.Instance.CARD_MENT[m_CardCode],
                    "N¡¿2");
        }
    }
    int ATK2(int dice)
    {
        return dice * 2;
    }
    string ATK3(bool read, int dice)
    {
        if (read)
        {
            return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                (12 - (dice * 2)).ToString());
        }
        return string.Format(
                Config.Instance.CARD_MENT[m_CardCode],
                "12-N¡¿2");
    }
    int ATK4(int dice)
    {
        return dice * 2;
    }
    int ATK5(int dice)
    {
        return dice * 2;
    }

    int ATK6(int dice)
    {
        return dice * 2;
    }
    int ATK7(int dice)
    {
        return dice * 2;
    }
    int ATK8(int dice)
    {
        return dice * 2;
    }
    int ATK9(int dice)
    {
        return dice * 2;
    }
    int ATK10(int dice)
    {
        return dice * 2;
    }


    int DPN1(int dice)
    {
        return dice * 2;
    }
    int DPN2(int dice)
    {
        return dice * 2;
    }
    int DPN3(int dice)
    {
        return dice * 2;
    }
    int DPN4(int dice)
    {
        return dice * 2;
    }
    int DPN5(int dice)
    {
        return dice * 2;
    }

    int DPN6(int dice)
    {
        return dice * 2;
    }
    int DPN7(int dice)
    {
        return dice * 2;
    }
    int DPN8(int dice)
    {
        return dice * 2;
    }
    int DPN9(int dice)
    {
        return dice * 2;
    }
    int DPN10(int dice)
    {
        return dice * 2;
    }


    int SKIL1(int dice)
    {
        return dice * 2;
    }
    int SKIL2(int dice)
    {
        return dice * 2;
    }
    int SKIL3(int dice)
    {
        return dice * 2;
    }
    int SKIL4(int dice)
    {
        return dice * 2;
    }
    int SKIL5(int dice)
    {
        return dice * 2;
    }
}
