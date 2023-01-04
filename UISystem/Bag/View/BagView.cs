using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagView : MyFramework.UIBaseView
{
    BagMode m_mode;
    BagCtrl m_ctrl;
    public UIGroup m_baglist;

    public BagView(GameObject go) : base(go)
    {
        m_mode = GetMode<BagMode>();
        m_ctrl = GetCtrl<BagCtrl>(m_mode);
    }
    public override void OnCreate()
    {
        base.OnCreate();
        m_baglist = AddComponent<UIGroup>("Scroll View");
        m_baglist.InitGroupItems<BagGroupItem>(m_mode.m_allitem.Count);
        m_baglist.RegisterClickHandle((BagGroupItem, index) =>
        {
            m_ctrl.C2S_UseItem(m_mode.m_allitem[index].m_name);
        });
        m_baglist.RegisterRefreshHandle((BagGroupItem, index) =>
        {
            ItemData data = m_mode.m_allitem[index];
            ((BagGroupItem)BagGroupItem).SetData(data);
        });
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnEnable(bool active)
    {
        Debug.Log("bag on OnEnable");
        base.OnEnable(active);
    }
}
