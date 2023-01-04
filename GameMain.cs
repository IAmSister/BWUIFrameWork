using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    void Start()
    {
        UIManager.GetInstance().Open<BagView>("uibag");
    }

    void Update()
    {
        UIManager.GetInstance().UpdateAllUI();
    }

    private void LateUpdate()
    {
        UIManager.GetInstance().LateUpdateAllUI();
    }
}
