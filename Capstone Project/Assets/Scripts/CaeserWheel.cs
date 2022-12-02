using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaeserWheel : MonoBehaviour
{
    private float zRotationPerLetter => (float)(360.0 / 26.0);

    private int totalShift;

    public Image OuterWheel;
    public TMP_InputField ShiftInput;

    public TMP_Text encodedText1;
    public TMP_Text encodedText2;
    public TMP_Text encodedText3;

    public TMP_Text decodedText1;
    public TMP_Text decodedText2;
    public TMP_Text decodedText3;

    public Canvas parentCanvas;
   
    // tuple format is: (decodedText, EncodedText, ShiftNumber)
    public Tuple<string, string, int>[] CypherTexts = {new("mtngrm", "ovpito", 2), new("officblck", "qhhkdnem", 2), new("GoLFGeNIUs", "MuRLMkTOAy", 6)};

    // Start is called before the first frame update
    void Start()
    {
        encodedText1.gameObject.SetActive(false);
        encodedText2.gameObject.SetActive(false);
        encodedText3.gameObject.SetActive(false);

        decodedText1.gameObject.SetActive(false);
        decodedText2.gameObject.SetActive(false);
        decodedText3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(StateController.receptionNoteFound == true) {
            encodedText1.gameObject.SetActive(true);
        }

        if(StateController.meetingRoomNoteFound == true) {
            encodedText2.gameObject.SetActive(true);
            encodedText3.gameObject.SetActive(true);
        }

    
    }

    public void ResetWheel()
    {
        OuterWheel.transform.rotation = Quaternion.identity;
        OuterWheel.transform.Rotate(new Vector3(0, 0, (float)5.898));
        totalShift = 0;
    }

    public void RotateWheel()
    {
        var shiftNum = int.Parse(ShiftInput.text);
        totalShift = shiftNum + totalShift;
        totalShift %= 26;

        OuterWheel.transform.Rotate(new Vector3(0, 0, shiftNum * zRotationPerLetter));
        foreach (var cypherText in CypherTexts)
        {
            if (cypherText.Item3 == totalShift)
            {
                if (cypherText.Item1.Equals("mtngrm") && StateController.receptionNoteFound == true) // Meeting Room Door 
                {
                    StateController.meetingRoomDoorOpen = true;
                    decodedText1.gameObject.SetActive(true);
                    Debug.Log("decoded1 set to active");
                }
                else if (cypherText.Item1.Equals("officblck") && StateController.meetingRoomNoteFound == true) // Office Block Door
                {
                    StateController.officeBlockDoorOpen = true;
                    decodedText2.gameObject.SetActive(true);
                    Debug.Log("decoded2 set to active");
                }
                else if (cypherText.Item1.Equals("GoLFGeNIUs") && StateController.meetingRoomNoteFound == true) // Derek Office Door
                {
                    StateController.DerekDoorOpen = true;
                    decodedText3.gameObject.SetActive(true);
                    Debug.Log("decoded3 set to active");
                }
            }
        }
    }
}
