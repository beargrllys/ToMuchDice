using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class CardDeque_Visible : MonoBehaviour
{
    const int MAX_VIS_CARD = 8;

    public Transform Lpoint, Rpoint;

    public GameObject[] CardObj = new GameObject[8];
    List<Vector3> CardPos = new List<Vector3>();

    private void Start()
    {
        int CaseLen = Mathf.Abs((int)Lpoint.position.x - (int)Rpoint.position.x);
        int offset = CaseLen / MAX_VIS_CARD;
        for(int i = 0; i < MAX_VIS_CARD; i++)
        {
            CardPos.Add(new Vector3(
                Lpoint.position.x + (offset*i),
                Lpoint.position.y,
                Lpoint.position.z
                ));
        }
    }

    public void Deque_Update(List<int> Display_Deque)
    {
        for(int i = 0; i < Display_Deque.Count; i++)
        {
            CardObj[i].SetActive(true);
            CardObj[i].transform.position = CardPos[i];
            CardObj[i].GetComponent<Card>().init_setting(Display_Deque[i]);
        }
        for (int i = Display_Deque.Count; i < MAX_VIS_CARD; i++)
        {
            CardObj[i].SetActive(false);
        }
    }
}
