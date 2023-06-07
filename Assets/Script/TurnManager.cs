using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour, IPointerClickHandler
{
    public int Turn;
    public int Used_Card;

    public Ally m_ally;
    public Enemy m_enemy;
    public DiceDeque m_dice;
    public CardDeque m_card;

    private string info_str = "TURN: {0}\nCARD: {1}";
    public TMP_Text Turn_Txt;

    public GameObject NewCardPanel;
    public SelecedCard[] NewCardPrefab = new SelecedCard[3];

    public GameObject ResultPanel;
    public TMP_Text SelectTxt;
    string SelectStr = "새로운 카드를 선택하세요.[{0}/3]";
    public Image Result;
    public Image Back_btn;
    public Sprite[] win_lose = new Sprite[2];
    public Sprite[] win_lose_btn = new Sprite[2];
    public List<int> new_select;

    private bool theEnd;
    bool is_win;



    private void Start()
    {
        m_ally = GameObject.FindGameObjectWithTag("ALLY").GetComponent<Ally>();

        m_enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
        m_card = GameObject.FindGameObjectWithTag("CARD").GetComponent<CardDeque>();
        Turn_Txt.text = string.Format(info_str, Turn, Used_Card.ToString());

        StartCoroutine(Loading());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null)
        {
            BattleStart();
            m_card.Remove_SkillCard();
            m_ally.Ready_Turn();
            m_enemy.Ready_Turn();
            Account_Card(0);
            m_card.Set_Trun_Draw();
            m_card.SKIL2_power = 0;
            Turn += 1;
        }
    }

    public void Account_Card(int reset = 1)
    {
        if (reset == 1)
        {
            Used_Card += 1;
        }
        else
        {
            Used_Card = 0;
        }
        Turn_Txt.text = string.Format(info_str, Turn, Used_Card.ToString());
    }
    // 전투 시작
    public void BattleStart()
    {
        m_ally.Take_Attack();
        m_enemy.Take_Attack();
    }
    //전투끝
    public void BattleEnd(bool winORlose)
    {
    //게임 종료 조건확인
        is_win = winORlose;
        if(BattleManage.Instance.battleTrun == 4)
        {
            BackToLobby();
        }
        if (is_win == false)
        {
            BattleResult();
            return;
        }
        NewCardPanel.SetActive(true);
        set_newCard_select();
    }
    //새 카드 선택 발동
    public void set_newCard_select()
    {
        SelectTxt.text = string.Format(SelectStr, new_select.Count + 1);
        for (int i = 0; i < 3; i++)
        {
            NewCardPrefab[i].SetCard();
        }
    }
    //전투 결과 
    public void BattleResult()
    {
        if (is_win == true)
        {
            for (int i = 0; i < 3; i++)
            {
                BattleManage.Instance.Add_newCard[new_select[i]] += 1;
            }
            NewCardPanel.SetActive(false);
        }
        if (theEnd == false)
        {
            theEnd = true;
            if (is_win)
            {
                Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.VICTORY);
                Result.sprite = win_lose[0];
                Result.SetNativeSize();
                Back_btn.sprite = win_lose_btn[0];
                ResultPanel.SetActive(true);
                BattleManage.Instance.battleTrun += 1;
                BattleManage.Instance.savedHP = m_ally.now_HP;
            }
            else
            {
                Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.DEFEAT);
                Result.sprite = win_lose[1];
                Result.SetNativeSize();
                Back_btn.sprite = win_lose_btn[1];
                ResultPanel.SetActive(true);
            }
        }
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene("Dungeon");
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        m_card.Deque_Arrange();
        m_enemy.Ready_Turn();
        m_ally.Ready_Turn();
    }

}
