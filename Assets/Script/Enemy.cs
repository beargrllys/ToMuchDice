using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public const int init_HP = 500;
    public int now_HP;

    public void Get_Damaged(int atk)
    {
        now_HP -= atk;
    }
}
