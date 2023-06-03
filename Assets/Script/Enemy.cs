using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Ally ally;
    public DiceDeque m_dice;

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
    public TMP_Text txt_UI;


    private void Start()
    {
        ally = GameObject.Find("ALLY").GetComponent<Ally>();
        m_dice = GameObject.FindGameObjectWithTag("DICE").GetComponent<DiceDeque>();
        now_HP = init_HP;
        now_Shield = max_Shield;
    }
    public void Get_Damaged(int atk)
    {
        if (now_Shield >= atk)
        {
            now_Shield -= atk;
        }
        else if (now_Shield < atk)
        {
            atk -= now_Shield;
            now_Shield = 0;
            now_HP -= atk;
            StartCoroutine(Damaged_Anime());
        }
        Update_Bar();
    }

    public void Get_Shield(int shd)
    {
        if (shd > 0)
        {
            now_Shield += shd;
            Update_Bar();
            StartCoroutine(Damaged_Anime());
        }
    }

    public void Take_Attack(int now_dealing)
    {
        StartCoroutine(Hit_Anime());
        ally.Get_Damaged(now_dealing);
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
                new Vector3(now_HP / init_HP, 1, 1);
        HP_txt.text = now_HP.ToString() + "[" + now_Shield.ToString() + "]";
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
