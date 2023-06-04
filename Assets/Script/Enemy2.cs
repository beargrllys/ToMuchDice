using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy2 : Enemy
{
    const int pattern_cnt = 3;
    public int pattern_now;

    public int now_dealing ;
    string dice_expain = "주사위[N]:{0}";
    string attack_expain = "\n{0}[{1}]만큼 공격";
    string defense_expain = "\n{0}[{1}]만큼 방어";
    public string full_expain;

    public bool flag;

    public void atk_pattern()
    {
        if (flag)
        {
            flag = false;
            rest();
            return;
        }
        pattern_now= Random.Range(0, pattern_cnt);
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

    public override void Ready_Turn()
    {
        now_dealing = 0;
        Get_Shield(0);
        atk_pattern();
        ExplainTxt.text = full_expain;
        Attack_Damage_txt.text = now_dealing.ToString();
        return;
    }

    public override void Take_Attack()
    {
        if(now_dealing < 0)
        {
            Get_Damaged(-1 * now_dealing);
            StartCoroutine(Damaged_Anime());
            return;
        }
        StartCoroutine(Hit_Anime());
        ally.Get_Damaged(now_dealing);
        now_dealing = 0;
        now_Shield = 0;
        Update_Bar();
    }

    public void pattern1()
    {
        int N = m_dice.Use_Dice();
        now_dealing = 40 + (N * 10);
        now_Shield = 0;
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += string.Format(dice_expain, N);
        full_expain += string.Format(attack_expain, "40+N×10",now_dealing);
        flag = true;
    }

    public void pattern2()
    {
        int N = m_dice.Use_Dice();
        now_dealing = 5 + (N * 2);
        now_Shield = (N * 4);
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += string.Format(dice_expain, N);
        full_expain += string.Format(attack_expain, "5+N×2", now_dealing);
        full_expain += string.Format(defense_expain, "N×4", now_Shield);
    }

    public void pattern3()
    {
        int N = m_dice.Use_Dice();
        now_Shield = 20 + (N * 3);
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += string.Format(dice_expain, N);
        full_expain += string.Format(defense_expain, "20+(N×3)", now_Shield);
    }

    public void rest()
    {
        now_dealing = 0;
        now_Shield = 0;
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += string.Format("1턴동안 아무것도 하지 않음");
    }
}
