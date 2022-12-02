using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecurityPassword : MonoBehaviour
{
    public TMP_InputField password;

    // Update is called once per frame
    void Update()
    {
        if (password.text == "14113") {
            StateController.securityDoorOpen = true;
        }
    }
}
