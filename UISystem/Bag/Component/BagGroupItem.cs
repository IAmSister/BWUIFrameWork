using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagGroupItem : UIGroupItem
{
    public UIImage m_icon;
    public UIText m_name;
    public BagGroupItem(GameObject go) : base(go)
    {
    }
    public override void OnCreate()
    {
        base.OnCreate();

        m_icon = AddComponent<UIImage>("icon");
        m_icon.SetSprite("icon_1");
        m_name = AddComponent<UIText>("name");
    }


    public void SetData(ItemData data) 
    {
        m_name.SetText(data.m_name);
        m_icon.SetSprite(data.m_icon);
    }

}
