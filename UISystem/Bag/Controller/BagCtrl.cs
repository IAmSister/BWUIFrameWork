using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCtrl : UIBaseCtrl
{
    public BagCtrl(UIBaseMode model) : base(model) { }


    public void C2S_UseItem(string name) 
    {
        Debug.Log("模拟向服务器发送使用:"+name);
    }
}
