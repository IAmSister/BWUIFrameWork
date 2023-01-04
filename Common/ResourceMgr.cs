using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class ResourceMgr : SingLetong<ResourceMgr>
{
    Dictionary<string, dynamic> _resources = new Dictionary<string, dynamic>();
    public Transform m_uiroot;

    public ResourceMgr()
    {
        m_uiroot = GameObject.Find("Canvas").transform;
    }

    static public T LoadResourceByType<T>(string _path) where T : UnityEngine.Object
    {
        T obj = null;
        if (GetInstance()._resources.ContainsKey(_path))
        {
            obj = GetInstance()._resources[_path] as T;
        }
        if (obj == null)
        {
            obj = Resources.Load<T>(_path);
            if (GetInstance()._resources.ContainsKey(_path))
            {
                obj = GetInstance()._resources[_path] as T;
            }
            else
            {
                GetInstance()._resources.Add(_path, obj);
            }
        }
        return obj;
    }

    static public GameObject LoadGoAndIns(string path) 
    {
        GameObject obj = LoadResourceByType<GameObject>(path);
        obj = GameObject.Instantiate(obj);
        obj.transform.SetParent(GetInstance().m_uiroot);
        obj.transform.localPosition = Vector3.zero;
        return obj;
    }
}
