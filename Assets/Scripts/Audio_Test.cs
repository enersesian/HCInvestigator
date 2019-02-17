using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Test : MonoBehaviour {

    AudioSource audio;
    public Text number;
    public string filepath;
	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
        int min = 0;
        int max = 0;
        //int i = Microphone.devices.Length;
        number.text += "\n" + Microphone.devices.Length.ToString();

        for(int i = 0; i < Microphone.devices.Length; i++ )
        {
            Debug.Log("Here");
            number.text += "\n" + Microphone.devices[i];
            number.text += Microphone.GetPosition(Microphone.devices[i]);
        }
      
        Microphone.GetDeviceCaps(null, out min, out max);
        audio.clip = Microphone.Start(null, true, 10, max);
        while (!(Microphone.GetPosition(null) > 0)) { }
       // audio.Play();
        
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
        {
            Debug.Log("Recorded");
           // audio.Stop();
            Microphone.End(null);
            SavWav.Save("clip", audio.clip);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            number.text += "\n" + "Pressed";
            Microphone.End(null);
            SavWav.Save("clip222222222", audio.clip);
        }



    }

    void OnApplicationQuit()
    {
        audio.Stop();
        Microphone.End(null);
        SavWav.Save("clip22222", audio.clip);
    }
    
}
