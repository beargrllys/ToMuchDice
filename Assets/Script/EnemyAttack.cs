using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAttack : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Board;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Board.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Board.SetActive(false);
    }
}
