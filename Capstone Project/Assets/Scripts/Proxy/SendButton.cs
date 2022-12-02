using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{
    void Start()
    {
        if (CompareTag("send"))
        {
            GetComponent<Button>().onClick.AddListener(ProxyHistory.Send);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}