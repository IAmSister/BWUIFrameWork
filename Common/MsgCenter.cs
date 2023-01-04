using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EventType:byte
{
    Common,//公用事件
    System,//系统间交互事件
}
public class MsgCenter 
{
    static MsgCenter _instance;
    static MsgCenter GetInstance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new MsgCenter();
            }
            return _instance;
        }
    }
    Dictionary<EventType,Dictionary<string,Action<List<decimal>>>> _allmsg;

    static public void RegisterMsg(EventType type,string msg, Action<List<decimal>> _func ) 
    {
        Dictionary<string, Action<List<decimal>>> action;
        if (GetInstance._allmsg.TryGetValue(type, out action)) 
        {
            if (action.ContainsKey(msg))
            {
                action[msg] += _func;
            }
        }
        else
        {
            GetInstance._allmsg.Add(type, new Dictionary<string, Action<List<decimal>>>());
            GetInstance._allmsg[type].Add(msg, _func);
        }
    }

    static public void UnRegisterMsg(EventType type,string msg, Action<List<decimal>> _func)
    {
        Dictionary<string, Action<List<decimal>>> action;
        if (GetInstance._allmsg.TryGetValue(type, out action))
        {
            if (action.ContainsKey(msg))
            {
                action[msg] -= _func;
            }
        }
    }

    static public void BroadcastMsg(EventType type,string msg,List<decimal> data) 
    {
        if (GetInstance._allmsg.ContainsKey(type))
        {
            if (GetInstance._allmsg[type].ContainsKey(msg))
            {
                GetInstance._allmsg[type][msg].Invoke(data);
            }
        }
    }
}
