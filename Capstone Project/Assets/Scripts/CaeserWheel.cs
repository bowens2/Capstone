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
    public TMP_Text encodedSubtitle;
    public TMP_Text decodedSubtitle;
    public TMP_Text emptyPartialWidthBox;
    public Canvas parentCanvas;
   

    public Tuple<string, string, int>[] CypherTexts = {new("test", "sdqs", 2), new("testii", "alzapp", 7)};

    // Start is called before the first frame update
    void Start()
    {
        lastEncodeY = encodedSubtitle.transform.position.y;
        lastDecodeY = decodedSubtitle.transform.position.y;

        foreach (var cypherText in CypherTexts)
        {
            emptyPartialWidthBox.text = cypherText.Item2;
            float newY = lastEncodeY - 50;
            Instantiate(emptyPartialWidthBox, new Vector3(emptyPartialWidthBox.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
            lastEncodeY = newY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDecodedText(string text)
    {
        emptyPartialWidthBox.text = text;
        float newY = lastDecodeY - 50;
        Instantiate(emptyPartialWidthBox, new Vector3(emptyPartialWidthBox.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
        lastDecodeY = newY;
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
            if (cypherText.Item3 == totalShift && !decodedTexts.Contains(cypherText.Item1))
            {
                ShowDecodedText(cypherText.Item1);
                decodedTexts.Add(cypherText.Item1);
            }
        }
    }
}
