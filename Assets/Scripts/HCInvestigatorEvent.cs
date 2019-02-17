using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HCInvestigatorEvent : MonoBehaviour {

    public string EventName;
 
    //protected List<UnityAction> listenerList = new List<UnityAction>();

    public UnityEvent Event;

    //public delegate void Action();

    
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //takes delegate
    //tells manager to register delegate method
    protected void RegisterToManager(UnityAction method)
    {
        HCInvestigatorManager.instance.AddToDictionary(EventName);

    } 
}
