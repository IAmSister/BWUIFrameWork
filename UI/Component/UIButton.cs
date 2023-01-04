using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MyFramework.UIBaseContainer
{

    Button mybtn;
    public UIButton(GameObject go) : base(go)
    {
        mybtn = go.GetComponent<Button>();

    }
    public void OnClick(Action handle)
    {
        mybtn.onClick.AddListener(() => { handle?.Invoke(); });

    }

}
