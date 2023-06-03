using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardDeque : MonoBehaviour
{
    public CardDeque_Visible cardDeque_Visible;

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
    public List<int> m_Used_Deque = new List<int>();

    private List<Card> cards = new List<Card>();

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

        foreach(GameObject card in cardDeque_Visible.CardObj)
        {
            cards.Add( card.GetComponent<Card>());
        }
        init_Deque();
    }

    void init_Deque()
    {
        foreach(KeyValuePair<int,int> item in DEQUE_PULL)
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

    public void Draw_Card(int Card_cnt)
    {
        if(m_Ready_Deque.Count < Card_cnt)
        {
            for(int i = 0; i < m_Used_Deque.Count; i++)
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

    public void Use_Card(Card card)
    {
        //카드 효과 발동
        m_Used_Deque.Add(m_Display_Deque[card.CardIDX]);
        m_Display_Deque.RemoveAt((int)card.CardIDX);
        card.isUsed = false;
        cardDeque_Visible.Deque_Update(m_Display_Deque);
        card.click_card(true, true);
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
}
