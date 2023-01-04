using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData 
{
    public string m_icon;
    public string m_name;

    public ItemData(string icon,string name)
    {
        m_icon = icon;
        m_name = name;
    }
}

public class BagMode : UIBaseMode
{
    public Dictionary<int, ItemData> m_allitem = new Dictionary<int, ItemData>();
    public BagMode()
    {
        for (int i = 0; i < 80; i++)
        {
            m_allitem.Add(i , new ItemData("icon_4","测试"+(i+1)));
        }
    }
}
