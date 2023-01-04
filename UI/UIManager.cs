using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UILayer : byte
{
    Scene = 1,   //场景UI，处于所有UI的下层
    Backgroud,  //UI底板
    Info,       //元素层，结合底板使用
    Noraml,     //正常系统
    Tips,       //提示框
    Top,        //最上层，类似菊花条
}

public class UIManager : SingLetong<UIManager>
{

    public Dictionary<Type, MyFramework.UIBaseView> m_views = new Dictionary<Type, MyFramework.UIBaseView>();

    public void Open<T>(string path) where T:MyFramework.UIBaseView
    {
        T ui = CreateInstantiate<T>(path);
        ui.Create();
        ui.Enable(true);
        m_views.Add(ui.GetType(),ui);
    }

    public void Close<T>()
    {
        if (m_views.ContainsKey(typeof(T)))
        {
            m_views[typeof(T)].Destroy();
        }
    }
    public T CreateInstantiate<T>(string path) where T : MyFramework.UIBaseView
    {
        object go = ResourceMgr.LoadGoAndIns(path);
        T v = Activator.CreateInstance(typeof(T), go) as T;
        return v;
    }

    public void UpdateAllUI() 
    {
        using (var Enumerator = m_views.GetEnumerator())
        {
            while (Enumerator.MoveNext())
            {
                Enumerator.Current.Value.Update();
            }
        }
    }
    public void LateUpdateAllUI() 
    {
        using (var Enumerator = m_views.GetEnumerator())
        {
            while (Enumerator.MoveNext())
            {
                Enumerator.Current.Value.LateUpdate();
            }
        }
    }

}
