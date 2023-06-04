using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManage : MonoBehaviour
{
    private static BattleManage Battleinstance = null;

    void Awake()
    {
        if (null == Battleinstance)
        {
            Battleinstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static BattleManage Instance
    {
        get
        {
            if (null == Battleinstance)
            {
                return null;
            }
            return Battleinstance;
        }
    }

    public TurnManager turnManager;
    public int battleTrun;
    public int[] Add_newCard = new int[25];

    public int savedHP = 100;
    public float healWithStage = 0.1f;


}
