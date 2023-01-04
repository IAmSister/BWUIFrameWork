using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public abstract class UIBaseComponent
    {
        public GameObject m_go;

        public UIBaseComponent(GameObject go)
        {
            m_go = go;
        }

        public virtual void Create() 
        {
            OnCreate();
        }
        public virtual void Enable(bool active)
        {
            m_go.SetActive(active);
            OnEnable(active);
        }
        public virtual void Destroy() 
        {
            //GameObject.Destroy(m_go);
            m_go = null;
            OnDestroy();
        }

        //↓↓↓↓↓生命周期回调
        public virtual void OnCreate() { }
        public virtual void OnEnable(bool active) { }
        public virtual void OnDestroy() { }

        public virtual void Update() { }
        public virtual void LateUpdate() { }
    }
}
