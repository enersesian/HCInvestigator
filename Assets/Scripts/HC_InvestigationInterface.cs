using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles user interface with the recording system
/// </summary>
public abstract class HC_InvestigationInterface : MonoBehaviour
{
    /// <summary>
    /// Folder name to save a recording to
    /// </summary>
    private string folderName;
    /// <summary>
    /// Boolean that says whether or not video is currently being recorded
    /// </summary>
    private bool recordingVideo;

    /// <summary>
    /// AudioSource used to record voice
    /// </summary>
    private AudioSource aud;

    /// <summary>
    /// Boolean that says whether or not audio is currently being recorded
    /// </summary>
    private bool recordingAudio;

    /// <summary>
    /// Used for initialization
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Begins recording video if it is not currently being recorded
    /// </summary>
    public virtual void RecordVideo()
    {
        if (recordingVideo)
        {
            return;
        }

        recordingVideo = true;
        folderName = Application.persistentDataPath + "/" + HCInvestigatorManager.instance.videoFolderName +
            " " + DateTime.Now.ToString("MM-dd-yy hh_mm_ss");

        System.IO.Directory.CreateDirectory(folderName);
        StartCoroutine(CaptureScreenshot());
    }

    /// <summary>
    /// Begins recording audio
    /// </summary>
    public virtual void RecordAudio()
    {
        if(recordingAudio)
        {
            Microphone.End(Microphone.devices[0]);
            aud.clip = SavWav.TrimSilence(aud.clip, 0);
            SavWav.Save("test aduio", aud.clip);
        }
        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(null, true, 50, 44100);
        aud.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
    }


    /// <summary>
    /// Begins recording analytics as text data
    /// </summary>
    public virtual void RecordTextData(string input)
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

    /// <summary>
    /// Takes a screenshot of whatever is currently rendered on the screen
    /// </summary>
    /// <returns>Returns an IEnumerator object</returns>
    IEnumerator CaptureScreenshot()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            string path = string.Format("{0}/shot{1:D04}.png", folderName, Time.frameCount);

            Texture2D screenshot = new Texture2D(Screen.width, Screen.height);

            screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenshot.Apply();

            byte[] imageBytes = screenshot.EncodeToPNG();

            System.IO.File.WriteAllBytes(path, imageBytes);

            HCInvestigatorManager.instance.AddScreenshot(screenshot, path);
        }
    }
}
