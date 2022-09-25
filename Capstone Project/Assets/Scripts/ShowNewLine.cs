using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowNewLine : MonoBehaviour
{
    public TMP_Text newLineTextBox;
    public TMP_Text previousLineInput;
    public TMP_Text textToDuplicate;
    public Canvas parentCanvas;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    
    public void onEnter(string message) 
    {
        StartCoroutine(showMessage(previousLineInput.text));
    }
    
    public string showMessage(string text) 
    {
        newLineTextBox.text = "'" + text + "' is not a valid command";
        Instantiate(textToDuplicate, new Vector3(200, 700, 0), Quaternion.identity, parentCanvas.transform);
        return text;
    }
    
}
