using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Button button1;

    public void Test()
    {
        print("ButtonClick");
    }

    private void Start()
    {
        button1.onClick.AddListener(Test);
        button1.onClick.AddListener(TestInside);
    }

    public void TestInside()
    {
        print("buttonclickinside");
        button1.onClick.RemoveAllListeners();
    }
}
