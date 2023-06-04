using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy5 : Enemy
{
    const int pattern_cnt = 4;
    public int pattern_now;

    public int now_dealing ;
    string dice_expain = "�ֻ���[N]:{0}";
    string attack_expain = "\n{0}[{1}]��ŭ ����";
    string defense_expain = "\n{0}[{1}]��ŭ ���";
    public string full_expain;

    public bool secret_flag;

    public void atk_pattern()
    {
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

            case 3:
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
        if (secret_flag)
        {
            secret_flag = false;
            Attack_Damage_txt.text = "?";
        }
        else
        {
            Attack_Damage_txt.text = now_dealing.ToString();
        }
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
        now_dealing = cardDeque.getDisplayCnt() * (N + 1);
        now_Shield = 0;
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += string.Format(dice_expain, N);
        full_expain += string.Format(attack_expain, "(�÷��̾� �տ� �ִ� ī�� ��)��(N+1)", now_dealing);
    }

    public void pattern2()
    {
        int N = m_dice.Use_Dice();
        now_dealing = 0;
        now_Shield = 0;
        Get_Shield(now_Shield);
        m_dice.Reverse_AllDiceVal();
        full_expain = "";
        full_expain += "���� �ֻ��� 3�� ������ ��ȣ�� ������Ŵ";
    }

    public void pattern3()
    {
        int N = m_dice.Use_Dice();
        now_dealing = turnManager.Turn * (N + 1);
        secret_flag = true;
        now_Shield = 0;
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += "����� ���� �غ� ���Դϴ�.";
    }

    public void pattern4()
    {
        int N = m_dice.Use_Dice();
        now_dealing = (6 - turnManager.Turn) * (N + 1);
        secret_flag = true;
        now_Shield = 0;
        Get_Shield(now_Shield);
        full_expain = "";
        full_expain += "���� ���� �غ� ���Դϴ�.";
    }
}
