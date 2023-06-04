using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dungeon : MonoBehaviour
{
    public Transform[] StagePosition;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        int turn = BattleManage.Instance.battleTrun;
        character.transform.position = StagePosition[turn].position;
    }
    public void Go_Lobby()
    {
        Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.CHOICE);
        SceneManager.LoadScene("Lobby");
    }

    public void Click_Stage(int num)
    {
        int turn = BattleManage.Instance.battleTrun;
        if (num == turn+1)
        {
            Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.CHOICE);
            SceneManager.LoadScene("Battle" + num + "Scene");
        }
    }
}
