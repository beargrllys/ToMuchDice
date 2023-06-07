using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ally : MonoBehaviour
{
    public int init_HP = 100;
    public int max_Shield = 100;
    public int now_HP;
    public int now_Shield;
    public int ally_dealing;

    public Enemy m_enemy;
    public TurnManager turnManager;

    public Image Character_img;
    public Sprite Normal_motion, Hit_motion, Damaged_motion;
    public Image Shield_img;
    public Sprite Shield_icon, Shield_break_icon;
    public GameObject HP_Bar_img;
    public GameObject Shield_Bar_img;
    public TMP_Text HP_txt;
    public TMP_Text Shield_txt;
    public TMP_Text Dealing_txt;

    //--------------------특수 상황 변수------------
    public bool DPN8_flag; // 방어 후 방어도가 남아있으면 그 수치 그대로 공격으로 전환 

    private void Start()
    {
        m_enemy = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Enemy>();
        now_HP = BattleManage.Instance.savedHP + (int)((float)BattleManage.Instance.savedHP * BattleManage.Instance.healWithStage);
        Update_Bar();
    }

    /// <summary>
    /// Ally is get damage to Card number
    /// </summary>
    /// <param name="atk"></param>
    public void Get_Damaged(int atk)
    {
        if (now_Shield >= atk)
        {
            if (DPN8_flag && now_Shield != atk)
            {
                m_enemy.Get_Damaged(now_Shield - atk);
                DPN8_flag = false;
            }
            now_Shield = 0;
        }
        else if (now_Shield < atk)
        {
            atk -= now_Shield;
            now_Shield = 0;
            now_HP -= atk;
            Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.ENM_ATK);
            StartCoroutine(Damaged_Anime());
        }
        if(now_HP <= 0)
        {
            now_HP = 0;
            turnManager.BattleEnd(false);
            return;
        }
        Update_Bar();
    }
    // 아군 딜량 누적시 호출
    public void Accamulate_Deal(int deal)
    {
        ally_dealing += deal;
        Dealing_txt.text = ally_dealing.ToString();
    }
    //아군 공격 수행시 호출
    public void Take_Attack()
    {
        if (ally_dealing > 0)
        {
            m_enemy.Get_Damaged(ally_dealing);
            StartCoroutine(Hit_Anime());
        }
        else if(ally_dealing < 0)
        {
            Get_Damaged((-1) * ally_dealing);
            StartCoroutine(Damaged_Anime());
        }
        Update_Bar();
    }

    // 아군 방어력 획득시 호출
    public void Get_Shield(int shd)
    {
        if (shd >= 0)
        {
            now_Shield += shd;
            Update_Bar();
        }
    }
    
    //턴시작시 초기화
    public void Ready_Turn()
    {
        ally_dealing = 0;
        Get_Shield(0);
        Dealing_txt.text = ally_dealing.ToString();
    }

    //값 변경시 UI업데이트
    public void Update_Bar()
    {
        if(now_Shield > 0)
        {
            Shield_img.sprite = Shield_icon;
            Shield_Bar_img.transform.localScale = 
                new Vector3((float)now_Shield / max_Shield,1,1);
        }
        else
        {
            Shield_img.sprite = Shield_break_icon;
            Shield_Bar_img.transform.localScale =
                new Vector3(0, 1, 1);
        }
        HP_Bar_img.transform.localScale =
                new Vector3((float)now_HP / init_HP, 1, 1);
        HP_txt.text = now_HP.ToString();
        Shield_txt.text = now_Shield.ToString();
    }

    //현재 사용 카드 개수 
    public int Get_UsedCard_cnt()
    {
        return turnManager.Used_Card;
    }

    IEnumerator Damaged_Anime()
    {
        Character_img.sprite = Damaged_motion;
        yield return new WaitForSeconds(0.5f);
        Character_img.sprite = Normal_motion;
    }

    IEnumerator Hit_Anime()
    {
        Character_img.sprite = Hit_motion;
        yield return new WaitForSeconds(0.5f);
        Character_img.sprite = Normal_motion;
    }
}
