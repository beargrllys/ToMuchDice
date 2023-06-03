using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy1 : Enemy
{
    const int pattern_cnt = 3;
    public int pattern_now;

    public int now_dealing ;
    string dice_expain = "주사위[N]:{0}";
    string attack_expain = "\n{0}만큼 공격";
    string defense_expain = "\n{0}만큼 방어";

    public void atk_pattern()
    {
        pattern_now= Random.Range(0, pattern_cnt-1);

        switch(pattern_now)
        {
            case 0:
                pattern1();
                break;

            case 1:
                pattern2();
                break;

            case 2:
                pattern3();
                break;

            default:
                break;
        }
    }

    public void pattern1()
    {
        int N = m_dice.Use_Dice();
        now_dealing = 5 + (N * 4);
        txt_UI.text = "";
        txt_UI.text += string.Format(dice_expain, N);
        txt_UI.text += string.Format(attack_expain, "5+N×4");
    }

    public void pattern2()
    {
        int N = m_dice.Use_Dice();
        now_Shield = 3 + (N * 3);
        txt_UI.text = "";
        txt_UI.text += string.Format(dice_expain, N);
        txt_UI.text += string.Format(defense_expain, "3+N×3");
    }

    public void pattern3()
    {
        int N = m_dice.Use_Dice();
        now_dealing = 5 + (N * 3);
        now_Shield = N * 3;
        txt_UI.text = "";
        txt_UI.text += string.Format(dice_expain, N);
        txt_UI.text += string.Format(attack_expain, "5+N×3");
        txt_UI.text += string.Format(defense_expain, "N×3");
    }
}
