
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Redord_Test : MonoBehaviour {
    AudioSource aud;
    // Use this for initialization
    void Start () {
        
        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(Microphone.devices[0], true, 50, 44100);
        aud.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        aud.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
        {
            Debug.Log("Stop");
            Microphone.End(Microphone.devices[0]);
            aud.clip = SavWav.TrimSilence(aud.clip, 0);
            SavWav.Save("test aduio", aud.clip);
            aud.Stop();
        }
	}
}
