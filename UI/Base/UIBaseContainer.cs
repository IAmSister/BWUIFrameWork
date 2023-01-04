using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyFramework
{
    /// <summary>
    /// 组件基类管理
    /// </summary>
    public class UIBaseContainer : UIBaseComponent
    {
        /// <summary>
        /// 存放所有的组件
        /// </summary>
        Dictionary<string, UIBaseComponent> components;
       
        public UIBaseContainer(GameObject go) : base(go)
        {
            components = new Dictionary<string, UIBaseComponent>();
        }

        protected T AddComponent<T>(string path) where T : UIBaseComponent
        {
            GameObject son = this.m_go.transform.Find(path).gameObject;
            return AddComponent<T>(son, path);
        }
        /// <summary>
        /// 添加组件，如果重复添加，不会重新创建，但是会return已有的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="_key"></param>
        /// <returns></returns>
        protected T AddComponent<T>(GameObject go,string _key) where T : UIBaseComponent
        {
            object son = go;
            if (son == null)
            {
                Debug.Log("没找到组件");
                return null;
            }
            T retval;
            if (!components.ContainsKey(_key))
            {
                retval = Activator.CreateInstance(typeof(T), son) as T;
                retval.Create();
                components.Add(_key, retval);
            }
            else
            {
                //Debug.Log("组件名重复！！！");
                retval = components[_key] as T;
            }
            return retval;
        }

        public UIBaseComponent GetComponent<T>(string _key) where T:UIBaseComponent
        {
            UIBaseComponent value = null;
            components.TryGetValue(_key, out value);
            return value;
        }

        //public void Walk()
        //{

        //}

        //public void RemoveComponent()
        //{

        //}

        public override void Create()
        {
            base.Create();
        }

        public override void OnCreate()
        {
            if (components == null || components.Count == 0) return;
            using (var enumerator = components.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Value.OnCreate();
                }

            }
        }
        public override void OnEnable(bool active)
        {
            if (components == null || components.Count == 0) return;
            using (var enumerator = components.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Value.OnEnable(active);
                }

            }
        }

        public override void OnDestroy()
        {
            if (components == null || components.Count == 0) return;
            using (var enumerator = components.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Value.OnDestroy();
                }

            }
            components.Clear();
            components = null;

        }
    }
}
