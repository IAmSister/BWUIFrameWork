
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRaycastClick : MyFramework.UIBaseComponent
{
    Action<PointerEventData> m_call;
    public UIRaycastClick(GameObject go) : base(go)
    {
        m_go.GetComponent<RaycastHandle>().m_clickcall = (data) =>
        {
            m_call?.Invoke(data);
        };
    }

    public void SetClickCall(Action<PointerEventData> _call) 
    {
        m_call = _call;
    }

}
