using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaeserWheel : MonoBehaviour
{
    private float zRotationPerLetter => (float)(360.0 / 26.0);
    private float lastEncodeY;
    private float lastDecodeY;
    private int totalShift;
    private List<string> decodedTexts = new();

    public Image OuterWheel;
    public TMP_InputField ShiftInput;
    //public TMP_Text encodedSubtitle;
    //public TMP_Text decodedSubtitle;
    public TMP_Text encodedText1;
    public TMP_Text encodedText2;
    public TMP_Text decodedText1;
    public TMP_Text decodedText2;
    //public TMP_Text emptyPartialWidthBox2;
    public Canvas parentCanvas;
   
    // tuple format is: (decodedText, EncodedText, ShiftNumber, TextDisplayedInCaesarScene)
    public Tuple<string, string, int, bool>[] CypherTexts = {new("mtngrm","ovpito",2, false), new("officblck","qhhkdnem",2, false)};

    //private bool showingCiphertext1 = false;
    //private bool showingCiphertext2 = false;

    // Start is called before the first frame update
    void Start()
    {
        //lastEncodeY = encodedSubtitle.transform.position.y;
        lastEncodeY = 338;
        //lastDecodeY = decodedSubtitle.transform.position.y;
        lastEncodeY = -5;

        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var cypherText in CypherTexts)
        {
            if(cypherText.Item2.Equals("mtngrm") && StateController.showingCiphertext1 == false && StateController.receptionNoteFound == true) {
                StateController.showingCiphertext1 = true;
                //ShowEncodedText(cypherText.Item2);
                encodedText1.gameObject.SetActive(true);
            }
            
            else if(cypherText.Item2.Equals("officblck") && StateController.showingCiphertext2 == false && StateController.meetingRoomNoteFound == true) {
                StateController.showingCiphertext2 = true;
                //ShowEncodedText(cypherText.Item2);
                encodedText2.gameObject.SetActive(true);
            }
        }
    }

    //public void ShowEncodedText(string text)
    //{
    //    emptyPartialWidthBox1.text = text;
    //    float newY = lastEncodeY - 50;
    //    Instantiate(emptyPartialWidthBox1, new Vector3(emptyPartialWidthBox1.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
    //    lastEncodeY = newY;
    //}

    //public void ShowDecodedText(string text)
    //{
    //    emptyPartialWidthBox2.text = text;
    //    float newY = lastDecodeY - 50;
    //    Instantiate(emptyPartialWidthBox2, new Vector3(emptyPartialWidthBox2.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
    //    lastDecodeY = newY;
    //}

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
            if (cypherText.Item3 == totalShift && !decodedTexts.Contains(cypherText.Item1))
            {
                if (cypherText.Item1.Equals("mtngrm")) // Meeting Room Door 
                {
                    StateController.meetingRoomDoorOpen = true;
                }
                else if (cypherText.Item1.Equals("officblck")) // Office Block Door
                {
                    StateController.officeBlockDoorOpen = true;
                }
                ShowDecodedText(cypherText.Item1);
                decodedTexts.Add(cypherText.Item1);
            }
        }
    }
}
