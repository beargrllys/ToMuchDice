using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Ally ally;
    public DiceDeque m_dice;
    public TurnManager turnManager;
    public CardDeque cardDeque;
    public int init_HP;
    public int now_HP;
    public int max_Shield;
    public int now_Shield;

    public Image Character_img;
    public Sprite Normal_motion, Hit_motion, Damaged_motion;

    public Sprite Shield_icon, Shield_break_icon;
    public Image Shield_img;
    public GameObject HP_Bar_img;
    public GameObject Shield_Bar_img;
    public TMP_Text HP_txt;
    public TMP_Text Shield_txt;
    public TMP_Text Attack_Damage_txt;
    public GameObject ExplainBoard;
    public TMP_Text ExplainTxt;


    private void Start()
    {
        ally = GameObject.FindGameObjectWithTag("ALLY").GetComponent<Ally>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
        turnManager = GameObject.FindGameObjectWithTag("TURN").GetComponent<TurnManager>();
        cardDeque = GameObject.FindGameObjectWithTag("CARD").GetComponent<CardDeque>();
        init_HP = Config.Instance.MONSTER_HP[BattleManage.Instance.battleTrun];
        now_HP = init_HP;
    }
    public void Get_Damaged(int atk)
    {
        if(atk < 0)
        {
            ally.Get_Damaged(-1 * atk);
        }
        if (now_Shield >= atk)
        {
            now_Shield -= atk;
        }
        else if (now_Shield < atk)
        {
            atk -= now_Shield;
            now_Shield = 0;
            now_HP -= atk;
            Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.ENM_DPS);
            StartCoroutine(Damaged_Anime());
        }
        if (now_HP <= 0)
        {
            now_HP = 0;
            turnManager.BattleEnd(true);
            return;
        }
        Update_Bar();
    }

    public void Get_Shield(int shd)
    {
        if (shd >= 0)
        {
            now_Shield = shd;
            Update_Bar();
        }
    }

    public virtual void Ready_Turn()
    {
        return;
    }

    public virtual void Take_Attack()
    {
        return;
    }

    public virtual void Reset_Turn()
    {
        return;
    }

    public void Update_Bar()
    {
        if (now_Shield > 0)
        {
            Shield_img.sprite = Shield_icon;
            Shield_Bar_img.transform.localScale =
                new Vector3((float)now_Shield / max_Shield, 1, 1);
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

    public IEnumerator Damaged_Anime()
    {
        Character_img.sprite = Damaged_motion;
        yield return new WaitForSeconds(0.5f);
        Character_img.sprite = Normal_motion;
    }

    public IEnumerator Hit_Anime()
    {
        Character_img.sprite = Hit_motion;
        yield return new WaitForSeconds(0.5f);
        Character_img.sprite = Normal_motion;
    }
}
