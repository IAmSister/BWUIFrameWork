using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : MyFramework.UIBaseComponent
{
    Image m_Image;
    public UIImage(GameObject go) : base(go)
    {
        m_Image = go.GetComponent<Image>();
    }

    public void SetSprite(string sprite)
    {
        m_Image.sprite = ResourceMgr.LoadResourceByType<Sprite>(sprite);
    }

}
