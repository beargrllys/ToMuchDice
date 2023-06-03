using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public readonly int init_HP = 100;
    public int now_HP;

    /// <summary>
    /// Ally is get damage to Card number
    /// </summary>
    /// <param name="atk"></param>
    public void Get_Damaged(int atk)
    {
        now_HP -= atk;
    } 

    
}
