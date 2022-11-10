using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class ShowNewLine : MonoBehaviour
{
    
    private float lastLineY;
    private float lineStartX => userInfoLine.transform.position.x;

    public TMP_Text emptyFullWidthTextBox;
    public TMP_Text userInfoLine;
    public TMP_InputField previousLineInput;
    public Canvas parentCanvas;
    public List<TerminalCommand> terminalCommands = new();
    public bool endOfScreen = false;
    

    // Start is called before the first frame update
    void Start()
    {
        loadCommands();
        lastLineY = userInfoLine.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(endOfScreen) {
            reset();
        }
    }
    
    public void loadCommands() 
    {
        var jsonFiles = Directory.GetFiles(@"Assets\Resources\Json");
        foreach (var file in jsonFiles)
        {
            if (file.Contains("meta"))
                continue;

            var jsonText = File.ReadAllText(file);
            terminalCommands.Add(TerminalCommand.GetFromJson(jsonText));
        }
    }
    
    public void onEnter() 
    {
        var inputText = previousLineInput.text;
        var commandWord = inputText.Split(' ')[0];
        var commandIndex = inputText.IndexOf(" ");
        
        if(commandWord.Equals("reset") || lastLineY - 200 <= emptyFullWidthTextBox.transform.position.y) {
            reset();
            return;
        }
        foreach (var result in from command in terminalCommands where commandWord.Equals(command.CommandName) 
                 select command.ProcessCommandInput(inputText.Remove(0, commandIndex + 1)).Split("\n"))
        {
            ShowLines(result);
            return;
        }
        //miss-clicks and clicks outside the text line should be ignored
        if (!commandWord.Equals(""))
        {
            showLine("'" + inputText + "' is not a valid command");
            showNewInputLine();
        }
    }

    public void ShowLines(string [] lines)
    {
        foreach (var line in lines)
        {
            showLine(line);
        }
        
        if (lastLineY - 250 <= emptyFullWidthTextBox.transform.position.y) {
            Thread.Sleep(3000);
            endOfScreen = true;
            return;
        }
        showNewInputLine();
    }
    public void showLine(string line) {
        emptyFullWidthTextBox.text = line;
        float newY = lastLineY - 50;
        Instantiate(emptyFullWidthTextBox, new Vector3(emptyFullWidthTextBox.transform.position.x, newY, 0), Quaternion.identity, parentCanvas.transform);
        lastLineY = newY;
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

    public void reset() {
        SceneManager.LoadScene("TerminalScene");
    }
    
}
