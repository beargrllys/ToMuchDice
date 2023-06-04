using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public void DungeonStart()
    {
        Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.CHOICE);
        SceneManager.LoadScene("Dungeon");
    }

    public void Exit()
    {
        Config.Instance.Play_Sound_Effect((int)Config.SOUNF_EFFECT.CHOICE);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
