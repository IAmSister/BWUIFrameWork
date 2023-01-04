using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MyFramework.UIBaseComponent
{
    Text m_text;
    public UIText(GameObject go) : base(go)
    {
        m_text = m_go.GetComponent<Text>();
    }

    public void SetText(string str) 
    {
        m_text.text = str;
    }
    public void SetColor(Color c) 
    {
        m_text.color = c;
    }


}
