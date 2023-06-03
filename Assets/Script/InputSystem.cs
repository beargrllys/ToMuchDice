using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Card card;

    private Vector2 LeftUp = new Vector2(-503,640);
    private Vector2 RightDown = new Vector2(748, 167);

    //Drag 
    private RectTransform rectTr;
    private Vector3 pre_position;

    private float initialDistance;

    private void Start()
    {
        rectTr = GetComponent<RectTransform>(); //스크립트 위치의 Rect Transform
        card = GetComponent<Card>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        pre_position = rectTr.anchoredPosition;
        card.click_card(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTr.anchoredPosition += eventData.delta;  //드래그 이벤트 함수 선언 및 등록
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (is_DropArea())
        {
            Debug.Log("Card is Used");
            card.isUsed = true;
        }
        else
        {
            rectTr.localPosition = pre_position;
        }
        card.click_card(false);
    }

    public bool is_DropArea()
    {
        if(is_range(LeftUp.x, RightDown.x, rectTr.localPosition.x) 
            && is_range(RightDown.y, LeftUp.y, rectTr.localPosition.y))
        {
            return true;
        }
        return false;
    }
    
    bool is_range(float min, float max, float val)
    {
        if (min <= val && max >= val)
        {
            return true;
        }
        return false;
    }
}
