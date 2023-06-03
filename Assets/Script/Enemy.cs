using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Ally ally;

    public int init_HP;
    public int now_HP;
    public int max_Shield;
    public int now_Shield;

    public Sprite Shield_icon, Shield_break_icon;
    public Image Shield_img;
    public GameObject HP_Bar_img;
    public GameObject Shield_Bar_img;
    public TMP_Text HP_txt;


    private void Start()
    {
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
        }
        Update_Bar();
    }

    public void Get_Shield(int shd)
    {
        if (shd > 0)
        {
            now_Shield += shd;
            Update_Bar();
        }
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
}
