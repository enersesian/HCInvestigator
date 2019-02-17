using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Singleton class responsible for managing settings, references for recordings
/// </summary>
public class HCInvestigatorManager : MonoBehaviour
{
    /// <summary>
    /// Singleton variable
    /// </summary>
    public static HCInvestigatorManager instance;
    /// <summary>
    /// Folder name for audio recordings
    /// </summary>
    public string audioFolderName;
    /// <summary>
    /// Max duration to record audio 
    /// </summary>
    public float audioRecordDuration;
    /// <summary>
    /// Folder name for screenshots which can be used to create a video
    /// </summary>
    public string videoFolderName;
    /// <summary>
    /// Folder name for text data recordings
    /// </summary>
    public string textFolderName;

    /// <summary>
    /// Holds references to screenshots and their file paths
    /// </summary>
    private Dictionary<string, Texture2D> screenshots;


    /// <summary>
    /// Holds references to events made with HCInvestigatorEvent
    /// </summary>
    private Dictionary<string, UnityEvent> eventDict;

    /// <summary>
    /// Used for initialization before the game starts
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Used for initialization
    /// </summary>
    void Start()
    {
        screenshots = new Dictionary<string, Texture2D>();
        eventDict = new Dictionary<string, UnityEvent>();
    }

    /// <summary>
    /// Adds a screenshot to the screenshot references dictionary
    /// </summary>
    /// <param name="screenshot">A screenshot represented as a Texture2D object</param>
    /// <param name="filePath">The file path to the screenshot</param>
    public void AddScreenshot(Texture2D screenshot, string filePath)
    {
        screenshots.Add(filePath, screenshot);
    }

    public void AddToDictionary(string eventName)
    {
        UnityEvent thisevent = null;
        if (instance.eventDict.ContainsKey(eventName))
        {
            return;
        }
        else
        {
            thisevent = new UnityEvent();
            instance.eventDict.Add(eventName, thisevent);
        }
    }

    public void AddActionToDictionary(string eventName, UnityAction listener)
    {
        if(!eventDict.ContainsKey(eventName))
        {
            Debug.LogError("Key doesnt exist in dictionary");
        }

        else
        {

            eventDict[eventName].AddListener(listener);
        }
    }
}
