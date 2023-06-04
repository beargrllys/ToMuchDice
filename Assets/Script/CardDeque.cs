using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class CardDeque : MonoBehaviour
{
    public CardDeque_Visible cardDeque_Visible;
    public TurnManager turnManager;
    public DiceDeque diceDeque;

    public const int MAX_DISPLAY_CARD = 8;

    public Dictionary<int, int> DEQUE_PULL = new Dictionary<int, int>()
    {
        {(int)Config.CARD_VAL.ATK1, 5 },
        {(int)Config.CARD_VAL.ATK2, 0 },
        {(int)Config.CARD_VAL.ATK3, 0 },
        {(int)Config.CARD_VAL.ATK4, 0 },
        {(int)Config.CARD_VAL.ATK5, 0 },

        {(int)Config.CARD_VAL.ATK6, 1 },
        {(int)Config.CARD_VAL.ATK7, 0 },
        {(int)Config.CARD_VAL.ATK8, 0 },
        {(int)Config.CARD_VAL.ATK9, 0 },
        {(int)Config.CARD_VAL.ATK10, 0 },

        {(int)Config.CARD_VAL.DPN1, 5 },
        {(int)Config.CARD_VAL.DPN2, 0 },
        {(int)Config.CARD_VAL.DPN3, 0 },
        {(int)Config.CARD_VAL.DPN4, 0 },
        {(int)Config.CARD_VAL.DPN5, 0 },

        {(int)Config.CARD_VAL.DPN6, 0 },
        {(int)Config.CARD_VAL.DPN7, 0 },
        {(int)Config.CARD_VAL.DPN8, 0 },
        {(int)Config.CARD_VAL.DPN9, 0 },
        {(int)Config.CARD_VAL.DPN10, 0 },

        {(int)Config.CARD_VAL.SKIL1, 1 },
        {(int)Config.CARD_VAL.SKIL2, 0 },
        {(int)Config.CARD_VAL.SKIL3, 0 },
        {(int)Config.CARD_VAL.SKIL4, 0 },
        {(int)Config.CARD_VAL.SKIL5, 0 }
    };

    //0~4는 전시되고 있는 
    public List<int> m_Ready_Deque = new List<int>();
    public List<int> m_Display_Deque = new List<int>();
    public int getDisplayCnt()
    {
        return m_Display_Deque.Count;
    }
    public List<int> m_Used_Deque = new List<int>();

    public List<Card> cards = new List<Card>();

    //----------------------------카드스킬-------------------
    public int SKIL2_power;


    public List<T> GetShuffle<T>(List<T> _list)
    {
        for(int i = _list.Count - 1; i > 0; i--) {
            int rnd = Random.Range(0, i);

            T tmp = _list[i];
            _list[i] = _list[rnd];
            _list[rnd] = tmp;
        }

        return _list;
    }

    private void Start()
    {
        foreach (GameObject card in cardDeque_Visible.CardObj)
        {
            cards.Add( card.GetComponent<Card>());
        }
        init_Deque();
    }

    void init_Deque()
    {
        for (int i = 0; i < 25; i++)
        {
            DEQUE_PULL[i] += BattleManage.Instance.Add_newCard[i];
        }
        foreach (KeyValuePair<int,int> item in DEQUE_PULL)
        {
            for (int j = 0; j < item.Value; j++)
            {
                m_Ready_Deque.Add(item.Key);
            }
        }
        m_Ready_Deque = GetShuffle(m_Ready_Deque);
        Draw_Card((int)Config.CARD_DRAW.INIT_DRAW);
        cardDeque_Visible.Deque_Update(m_Display_Deque);
    }

    public void Deque_Arrange()
    {
        cardDeque_Visible.Deque_Update(m_Display_Deque);
    }

    public void Draw_Card(int Card_cnt)
    {
        if(m_Ready_Deque.Count < Card_cnt)
        {
            int Used_cnt = m_Used_Deque.Count;
            for (int i = 0; i < Used_cnt; i++)
            {
                m_Ready_Deque.Add(m_Used_Deque[0]);
                m_Used_Deque.RemoveAt(0);
            }
            
        }
        m_Ready_Deque = GetShuffle(m_Ready_Deque);
        for (int i = 0; i < Card_cnt; i++)
        {
            int tmp = m_Ready_Deque[0];
            m_Ready_Deque.RemoveAt(0);
            m_Display_Deque.Add(tmp);
        }
    }

    public void Set_Trun_Draw()
    {
        if(m_Display_Deque.Count == 7)
        {
            Draw_Card(1);
            return;
        }
        if (m_Display_Deque.Count == 8)
        {
            return;
        }
        if (m_Display_Deque.Count == 0)
        {
            Draw_Card(3);
        }
        else
        {
            Draw_Card(2);
        }
        cardDeque_Visible.Deque_Update(m_Display_Deque);
    }

    public void Use_Card(Card card)
    {
        //카드 효과 발동
        card.click_card(true, true);
        if (card.DPN10_flag == false)//DPN10 사용불가 조건
        {
            m_Used_Deque.Add(m_Display_Deque[card.CardIDX]);
            m_Display_Deque.RemoveAt((int)card.CardIDX);
            card.isUsed = false;
            cardDeque_Visible.Deque_Update(m_Display_Deque);
            turnManager.Account_Card();
        }
        else
        {
            card.DPN10_flag = false;
            card.isUsed = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        foreach(Card card in cards)
        {
            if (card.isUsed)
            {
                Use_Card(card);
            }
        }
    }

    public void Drop_Card(int index)
    {
        m_Used_Deque.Add(m_Display_Deque[index]);
        m_Display_Deque.RemoveAt(index);
        cardDeque_Visible.Deque_Update(m_Display_Deque);
    }

    public void Drop_Last_Card()
    {
        int last_card = m_Display_Deque.Count - 1;
        m_Used_Deque.Add(m_Display_Deque[last_card]);
        m_Display_Deque.RemoveAt(last_card);
        cardDeque_Visible.Deque_Update(m_Display_Deque);
    }

    public void Drop_All_Card(int CardIDX)
    {
        int last_card = m_Display_Deque.Count;
        for (int i = 0; i < last_card; i++)
        {
            if (CardIDX != i)
            {
                m_Used_Deque.Add(m_Display_Deque[0]);
                m_Display_Deque.RemoveAt(0);
            }
        }
        cardDeque_Visible.Deque_Update(m_Display_Deque);
    }

    public void ChangeAllDice()
    {
        diceDeque.Change_DiceVal(1);
    }

    public void NextDiceInc()
    {
        diceDeque.Change_DiceVal(1);
    }

    public void NextDiceRed()
    {
        diceDeque.Change_DiceVal(-1);
    }

    public void Remove_SkillCard()
    {
        for(int i = 0; i < m_Display_Deque.Count; i++)
        {
            if (20 <= m_Display_Deque[i] && 24>= m_Display_Deque[i])
            {
                Drop_Card(i);
                i -= 1;
            }
        }
    }
}
