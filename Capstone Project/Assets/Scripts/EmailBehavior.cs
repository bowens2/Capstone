using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void FocusEmailOne() 
    {
        emailBodyBox.text = "email 1 body";
        emailFromBox.text = "from1@from.com";
        emailSubjectBox.text = "subject 1";
        emailReceivedBox.text = "Received 01:MM YYYY/MM/DD";
        currentEmail = 1;
    }
    public void FocusEmailTwo()
    {
        emailBodyBox.text = "email 2 body";
        emailFromBox.text = "from2@from.com";
        emailSubjectBox.text = "subject 2";
        emailReceivedBox.text = "Received 02:MM YYYY/MM/DD"; 
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
