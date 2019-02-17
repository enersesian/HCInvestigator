using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component used for setting physcial button pushes to record a certain type of data when pressed
/// </summary>
public class Phys_HCInvestigator : HC_InvestigationInterface
{
    /// <summary>
    /// enum for which button usage we are looking for
    /// </summary>
    public enum ButtonType
    {
        Trigger,
        TouchPad
    }
    /// <summary>
    /// enum for which Recording Type we want
    /// </summary>
    public enum RecordingType
    {
        Video,
        Audio,
        Text
    }

    /// <summary>
    /// Struct to hold both the button type and recording type we want
    /// System.Serializable allows us to edit the types in the inspector
    /// </summary>
    [System.Serializable]
    public struct Recording
    {
        public ButtonType button;
        public RecordingType record;
    }


    public Recording RecordPhysButton;

    // Use this for initialization
    void Start() {



    }

    // Update is called once per frame
    void Update() {

        //Checks to see if the player has hit the trigger and checks to see if the trigger is the desired button
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && RecordPhysButton.button == ButtonType.Trigger)
        {
            RecordTypeCheck();
        }

        //Checks to see if the player has hit the touchpad and checks to see if the touchpad is the desired button
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) && RecordPhysButton.button == ButtonType.TouchPad)
        {
           RecordTypeCheck();
        }

    }

    /// <summary>
    /// Checks to see what record type has been selected and then calls the appropriate from the Parent Class
    /// </summary>
    private void RecordTypeCheck()
    {
        if (RecordPhysButton.record == RecordingType.Video)
        {
            RecordVideo();
        }
        else if (RecordPhysButton.record == RecordingType.Audio)
        {
            RecordAudio();
        }
        else if (RecordPhysButton.record == RecordingType.Text)
        {
            //RecordTextData(string input);
        }
    }
}
