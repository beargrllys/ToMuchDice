using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDeque : MonoBehaviour
{
    private int[] Dice_Num = new int[7] { -1, 1, 2, 3, 4, 5, 6 };
    private List<int> Dice_List = new List<int>();

    // �ʱ⿡ 3���� �������� Dice_List�� �߰��Ѵ�.
    void Start()
    {
        
    }

    // Dice_Num �迭 �� �� �ϳ��� �����ϰ� ��ȯ�Ѵ�.
    // �̶� -1�� 5%Ȯ���� �������� �Ѵ�.
    int Random_Dice()
    {
        return 0;
    }

    //Dice_List�� ���� �տ� �ִ� ���� ��ȯ�ϰ� Dice_List�� �ش簪�� �����Ѵ�.
    //�׸��� ���ο� �ֻ��� ���� �����Ѵ�.
    int Use_Dice()
    {
        return 0;
    }

}
