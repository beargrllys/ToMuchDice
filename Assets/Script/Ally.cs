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

    public Image Character_img;
    public Sprite Normal_motion, Hit_motion, Damaged_motion;

    public Sprite Shield_icon, Shield_break_icon;
    public Image Shield_img;
    public GameObject HP_Bar_img;
    public GameObject Shield_Bar_img;
    public TMP_Text HP_txt;

    private void Start()
    {
        now_HP = init_HP;
        now_Shield = 10;
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
