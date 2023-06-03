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

    // Dice_Num 배열 값 중 하나를 랜덤하게 반환한다.
    // 이때 -1이 5%확률로 나오도록 한다.
    int Random_Dice()
    {
        //5%확률로 -1
        int randomValue = random.Next(0,100);
        if(randomValue == 0) {
            return -1;
        }
        else{ //5% 뚫으면 1~6사이의 값은 고른 확률로 나옴
            randomValue = random.Next(1,7);
            return randomValue;
        }
    }


    // // 초기에 3개의 랜덤값을 Dice_List에 추가한다.
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

    //Dice_List의 가장 앞에 있는 값을 반환하고 Dice_List의 해당값을 삭제한다.
    //그리고 새로운 주사위 값을 보충한다.
    public int Use_Dice()
    {
        int curr_Dice = Dice_List[0]; //current Dice값을 int로 받음.
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
