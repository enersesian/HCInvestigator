using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data and functions for creating a UI button 
/// </summary>
public class UI_Button : HC_InvestigationInterface
{
    /// <summary>
    /// Recording types
    /// </summary>
    public enum RecordType
    {
        /// <summary>
        /// Record video
        /// </summary>
        Video,
        /// <summary>
        /// Record audio
        /// </summary>
        Audio,
        /// <summary>
        /// Record text
        /// </summary>
        Text
    };

    /// <summary>
    /// The type of data that this button will begin the recording of
    /// </summary>
    public RecordType recordType;

    /// <summary>
    /// Called whenever the button is clicked
    /// </summary>
    public void OnClick()
    {
        switch (recordType)
        {
            case RecordType.Video:
                RecordVideo();
                break;

            case RecordType.Audio:
                RecordAudio();
                break;

            case RecordType.Text:
                //RecordTextData();
                break;
        }
    }
}
