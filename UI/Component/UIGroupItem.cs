using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIGroupItem : MyFramework.UIBaseContainer
{
    public UIRaycastClick m_btn;
    public UIGroupItem(GameObject go) : base(go)
    {
        m_btn = AddComponent<UIRaycastClick>(m_go,"btn_main");
    }
}
