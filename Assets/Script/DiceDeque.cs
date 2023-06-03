using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceDeque : MonoBehaviour
{
    const int MAX_DICE = 3;

    private int[] Dice_Num = new int[7] { -1, 1, 2, 3, 4, 5, 6 };
    public List<int> Dice_List = new List<int>();
    //public List<TMP_Text> Dice_UI= new List<TMP_Text>();

    public Image[] Dice_UI = new Image[3];
    public Sprite[] Dice_Sprite = new Sprite[15];

    System.Random random = new System.Random();

    // Dice_Num �迭 �� �� �ϳ��� �����ϰ� ��ȯ�Ѵ�.
    // �̶� -1�� 5%Ȯ���� �������� �Ѵ�.
    int Random_Dice()
    {
        //5%Ȯ���� -1
        int randomValue = random.Next(0,100);
        if(randomValue == 0) {
            return -1;
        }
        else{ //5% ������ 1~6������ ���� �� Ȯ���� ����
            randomValue = random.Next(1,7);
            return randomValue;
        }
    }


    // // �ʱ⿡ 3���� �������� Dice_List�� �߰��Ѵ�.
    void Start()
    {
        init_DiceQueue();
    }

    void init_DiceQueue()
    {
        for (int i = 0; i < MAX_DICE; i++)
        {
            Dice_List.Add(Random_Dice());
        }
        Update_DiceUI();
    }

    //Dice_List�� ���� �տ� �ִ� ���� ��ȯ�ϰ� Dice_List�� �ش簪�� �����Ѵ�.
    //�׸��� ���ο� �ֻ��� ���� �����Ѵ�.
    public int Use_Dice()
    {
        int curr_Dice = Dice_List[0]; //current Dice���� int�� ����.
        Dice_List.RemoveAt(0);
        Dice_List.Add(Random_Dice());
        Update_DiceUI();
        return curr_Dice;
    }

    public int Get_Dice(int idx = 0)
    {
        return Dice_List[idx];
    }

    void Update_DiceUI()
    {
        for(int i = 0; i < MAX_DICE; i++)
        {
            Dice_UI[i].sprite = Dice_Sprite[Dice_List[i]+7];
        }
    }

}
