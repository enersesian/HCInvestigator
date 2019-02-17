using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextRecording : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        if(Input.GetKeyDown("a"))
        {
            WrtieToFile("testesteststbbbbbbbb");
        }

	}


    public void WrtieToFile(string input)
    {
        string path = Application.persistentDataPath + "/TextFile.txt";
        if (System.IO.File.Exists(path))
        {
            StreamWriter wrtier = System.IO.File.AppendText(path);
            wrtier.WriteLine(input);
            wrtier.Close();
        }
        else
        {
            StreamWriter wrtier = System.IO.File.CreateText(path);
            wrtier.WriteLine(input);
            wrtier.Close();
        }
    }

}
