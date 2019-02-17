using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerTest : MonoBehaviour {

	
	void Update () {
		if(Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }
	}
}
