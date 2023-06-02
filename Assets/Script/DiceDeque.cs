using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDeque : MonoBehaviour
{
    private int[] Dice_Num = new int[7] { -1, 1, 2, 3, 4, 5, 6 };
    private List<int> Dice_List = new List<int>();

    // 초기에 3개의 랜덤값을 Dice_List에 추가한다.
    void Start()
    {
        
    }

    // Dice_Num 배열 값 중 하나를 랜덤하게 반환한다.
    // 이때 -1이 5%확률로 나오도록 한다.
    int Random_Dice()
    {
        return 0;
    }

    //Dice_List의 가장 앞에 있는 값을 반환하고 Dice_List의 해당값을 삭제한다.
    //그리고 새로운 주사위 값을 보충한다.
    int Use_Dice()
    {
        return 0;
    }

}
