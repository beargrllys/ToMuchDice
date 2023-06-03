using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private static Config instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static Config Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    //카드종류 
    public enum CARD_VAL
    {
        ATK1 = 0,
        ATK2,
        ATK3,
        ATK4,
        ATK5,

        ATK6,
        ATK7,
        ATK8,
        ATK9,
        ATK10,

        DPN1,
        DPN2,
        DPN3,
        DPN4,
        DPN5,

        DPN6,
        DPN7,
        DPN8,
        DPN9,
        DPN10,

        SKIL1,
        SKIL2,
        SKIL3,
        SKIL4,
        SKIL5,

    }
    //카드 드로우 개수
    public enum CARD_DRAW
    {
        INIT_DRAW = 5,
        NORMAL_DRAW = 2,
        EMPTY_DRAW = 3
    }

    public enum CARD_ABILITY
    {
        ATTACK = 0,
        DEFENSE
    }

    public List<string> CARD_MENT = new List<string>()
    {
        "[{0}]만큼 공격",
        "2만큼 공격 [{0}]번 반복",
        "[{0}]만큼 공격",
        "[{0}]만큼 공격",
        "[{0}]만큼 공격",

        "[{0}]만큼 공격",
        "2만큼 공격 [{0}]번 반복",
        "[{0}]만큼 공격",
        "[{0}]만큼 공격",
        "[{0}]만큼 공격",

        "[{0}]만큼 방어",
        "2만큼 방어 [{0}]번 반복",
        "[{0}]만큼 방어",
        "[{0}]만큼 방어",
        "[{0}]만큼 방어",

        "[{0}]만큼 방어",
        "2만큼 방어 [{0}]번 반복",
        "[{0}]만큼 방어",
        "[{0}]만큼 방어",
        "[{0}]만큼 방어",


        "[{0}]만큼 스킬",
        "2만큼 스킬 [{0}]번 반복",
        "[{0}]만큼 스킬",
        "[{0}]만큼 스킬",
        "[{0}]만큼 스킬",
    };

    public Dictionary<int, int> CARD_COUNT = new Dictionary<int, int>()
    {
        {(int)CARD_VAL.ATK1, 5 },
        {(int)CARD_VAL.ATK2, 5 },
        {(int)CARD_VAL.ATK3, 5 },
        {(int)CARD_VAL.ATK4, 5 },
        {(int)CARD_VAL.ATK5, 5 },

        {(int)CARD_VAL.ATK6, 5 },
        {(int)CARD_VAL.ATK7, 5 },
        {(int)CARD_VAL.ATK8, 5 },
        {(int)CARD_VAL.ATK9, 5 },
        {(int)CARD_VAL.ATK10, 5 },

        {(int)CARD_VAL.DPN1, 5 },
        {(int)CARD_VAL.DPN2, 5 },
        {(int)CARD_VAL.DPN3, 5 },
        {(int)CARD_VAL.DPN4, 5 },
        {(int)CARD_VAL.DPN5, 5 },

        {(int)CARD_VAL.DPN6, 5 },
        {(int)CARD_VAL.DPN7, 5 },
        {(int)CARD_VAL.DPN8, 5 },
        {(int)CARD_VAL.DPN9, 5 },
        {(int)CARD_VAL.DPN10, 5 },

        {(int)CARD_VAL.SKIL1, 5 },
        {(int)CARD_VAL.SKIL2, 5 },
        {(int)CARD_VAL.SKIL3, 5 },
        {(int)CARD_VAL.SKIL4, 5 },
        {(int)CARD_VAL.SKIL5, 5 }
    };
}
