using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制
/// </summary>
public abstract class UIBaseCtrl 
{
    //面板模式
    private UIBaseMode m_mode;
    public UIBaseCtrl(UIBaseMode model)
    {
        m_mode = model;
    }
    /// <summary>
    /// 获取模式
    /// </summary>
    /// <typeparam name="T">任意类型</typeparam>
    /// <returns></returns>
    protected T GetMode<T>() where T:UIBaseMode
    {
        T mode = null;
        if (m_mode != null)
        {
            mode = m_mode as T;
        }
        return mode;
    }
    /// <summary>
    /// 抛出系统事件，用于通知V层刷新界面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="_data"></param>
    protected void BroadcastSystemMsg(string msg,params decimal[] _data) 
    {
        List<decimal> data = new List<decimal>(_data);
        MsgCenter.BroadcastMsg(EventType.System, msg, data);
    }

    
}
