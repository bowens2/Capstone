using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EmailBehavior : MonoBehaviour
{
    private string emailOneKey = "email1key";
    private string emailTwoKey = "email2key";

    public TMP_Text emailBodyBox;
    public TMP_Text emailFromBox;
    public TMP_Text emailSubjectBox;
    public TMP_Text emailReceivedBox;
    public TMP_InputField decryptInput;
    private int currentEmail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CopyFocusedEmail() 
    {
        GUIUtility.systemCopyBuffer = emailBodyBox.text;
    }

    public void GoToTerminal()
    {
        SceneManager.LoadScene("TerminalScene");
    }

    public void FocusEmailOne() 
    {
        emailBodyBox.text = "BEGIN ENCRYPT AvjzjAsjJJZJIEPLlj908 END";
        emailFromBox.text = "Derek <dererk@hugetech.com>";
        emailSubjectBox.text = "Caesar";
        emailReceivedBox.text = "Received 01:03 2077/01/14";
        currentEmail = 1;
    }
    public void FocusEmailTwo()
    {
        emailBodyBox.text = "BEGIN ENCRYPT jiopfnvNJJJOjkj08888nJ END";
        emailFromBox.text = "Sandy <sandy@hugetech.com>";
        emailSubjectBox.text = "Door";
        emailReceivedBox.text = "Received 02:23 2077/01/10"; 
        currentEmail = 2;
    }

    public void Decrypt() 
    {
        if (currentEmail == 1 && decryptInput.text.Equals(emailOneKey)) 
            emailBodyBox.text = "email 1 decrypted body";
        else if (currentEmail == 2 && decryptInput.text.Equals(emailTwoKey))
            emailBodyBox.text = "email 2 decrypted body";
        else
            emailBodyBox.text = "Error: invalid key";
    }
}
