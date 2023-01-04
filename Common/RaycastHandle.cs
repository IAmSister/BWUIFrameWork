using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastHandle : MonoBehaviour,IPointerClickHandler
{
    public Action<PointerEventData> m_clickcall;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        m_clickcall?.Invoke(eventData);
    }

}
