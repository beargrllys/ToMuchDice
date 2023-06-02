using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDeque : MonoBehaviour
{
    private int[] Dice_Num = new int[7] { -1, 1, 2, 3, 4, 5, 6 };
    private List<int> Dice_List = new List<int>();
 
    System.Random random = new System.Random();

    // Dice_Num �迭 �� �� �ϳ��� �����ϰ� ��ȯ�Ѵ�.
    // �̶� -1�� 5%Ȯ���� �������� �Ѵ�.
    int Random_Dice()
    {
        //5%Ȯ���� -1
        int randomValue = random.Next(0,20);
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
        for (int i = 0; i<3; i++){
            Dice_List.Add(Random_Dice());
        }
    }

    //Dice_List�� ���� �տ� �ִ� ���� ��ȯ�ϰ� Dice_List�� �ش簪�� �����Ѵ�.
    //�׸��� ���ο� �ֻ��� ���� �����Ѵ�.
    int Use_Dice()
    {
        int curr_Dice = Dice_List[0]; //current Dice���� int�� ����.
        Dice_List.RemoveAt(0);
        Dice_List.Add(Random_Dice());
        return curr_Dice;
    }

}
