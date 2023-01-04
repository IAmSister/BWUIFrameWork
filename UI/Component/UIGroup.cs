using System;
using UnityEngine;
using AillieoUtils;
public class UIGroup : MyFramework.UIBaseContainer
{
    ScrollView m_group;
    Action<UIGroupItem, int> m_refresh_call;
    Action<UIGroupItem, int> m_click_call;
    int m_cout;
    //decimal m_itemtype;

    public UIGroup(GameObject go) : base(go)
    {
    }
    public override void OnCreate()
    {
        m_group = m_go.transform.GetComponent<ScrollView>();
        if (!m_group)
        {
            Debug.LogError("!!!!未找到组件 InfinityGridLayoutGroup  请手动挂上去");
            return;
        }
        base.OnCreate();
    }
    public void InitGroupItems<T>(int count) where T : UIGroupItem
    {
        m_cout = count;
        m_group.SetItemCountFunc(() => { return m_cout; });
        m_group.SetUpdateFunc((_index, _item) =>
            {
                GameObject go = _item.gameObject;
                go.name = _index.ToString();
                var item = AddComponent<T>(go.gameObject, "item_" + _index);
                
                m_refresh_call?.Invoke(item,int.Parse( item.m_go.name));
                item.m_btn.SetClickCall((data) =>
                {
                    m_click_call?.Invoke(item, int.Parse(item.m_go.name));
                });
            });
        m_group.UpdateData(false);
        m_group.UpdateDataIncrementally(false);
    }

    public void RegisterClickHandle(Action<UIGroupItem, int> click_call) 
    {
        m_click_call = click_call;
    }

    public void RegisterRefreshHandle(Action<UIGroupItem, int> refresh_call) 
    {
        m_refresh_call = refresh_call;
    }

}
