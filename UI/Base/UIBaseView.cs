using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MyFramework
{
    public abstract class UIBaseView : UIBaseContainer
    {
        public UIBaseView(GameObject go) : base(go)
        {
        }

        public override void OnCreate()
        {
            RegisterHandle();
            base.OnCreate();
        }
        public override void Destroy()
        {
            UnRegisterHanle();
            GameObject.Destroy(m_go);
            base.Destroy();
        }

        public virtual void RegisterHandle() 
        {
        }

        public virtual void UnRegisterHanle() 
        {
            
        }

        internal T GetCtrl<T>(UIBaseMode mode) where T : UIBaseCtrl
        {

            T v = Activator.CreateInstance(typeof(T),mode) as T;
            return v;
        }
        internal T GetMode<T>() where T : UIBaseMode
        {

            T v = Activator.CreateInstance<T>();
            return v;
        }
    }
}
