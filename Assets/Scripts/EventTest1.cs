using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest1 : MonoBehaviour {

    private UnityAction someListner;

    public UnityAction listen2;

    public System.Delegate tester;
    void Awake()
    {
        someListner = new UnityAction(SomeFunction);
    }

    void OnEnable()
    {
        EventManager.StartListening("test", someListner);
    }
    void OnDisable()
    {
        EventManager.StopListening("test", someListner);
    }

    void SomeFunction()
    {
        Debug.Log("Some Function");
    }
    void SomeFunction2()
    {

    }
}
