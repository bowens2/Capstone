using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShowNewLine : MonoBehaviour
{
    
    private float lastLineY;
    private float lineStartX => userInfoLine.transform.position.x;

    public TMP_Text emptyFullWidthTextBox;
    public TMP_Text userInfoLine;
    public TMP_InputField previousLineInput;
    public Canvas parentCanvas;


    // Start is called before the first frame update
    void Start()
    {
        lastLineY = userInfoLine.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    
    public void onEnter() 
    {
        var commands = new List<TerminalCommand>();
        commands.Add(TerminalCommand.GetFromJson("{\"CommandName\": \"test\", \"InvalidArgsMessage\": \"invalid input\", \"IOPairs\": [{\"ExpectedInput\": \"hi\", \"Output\":\"bye\"}]}"));
        var inputText = previousLineInput.text;
        var commandWord = inputText.Split(' ')[0];
        var commandIndex = inputText.IndexOf(" ");
        foreach (var command in commands) {
            if (commandWord.Equals(command.CommandName))
            {
                showLine(command.ProcessCommandInput(inputText.Remove(0, commandIndex + 1)));
                return;
            }
        }

        showLine("'" + inputText + "' is not a valid command");
    }

    public void showLine(string line) {
        emptyFullWidthTextBox.text = line;
        float newY = lastLineY - 50;
        Instantiate(emptyFullWidthTextBox, new Vector3(emptyFullWidthTextBox.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
        lastLineY = newY;
        showNewInputLine();
    }

    public void showNewInputLine() 
    {
        float newY = lastLineY - 50;
        userInfoLine = Instantiate(userInfoLine, new Vector3(userInfoLine.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
        TMP_InputField newInput = Instantiate(previousLineInput, new Vector3(previousLineInput.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
        newInput.text = "";
        newInput.ActivateInputField();
        previousLineInput = newInput;
        lastLineY = newY;
    }
    
}
