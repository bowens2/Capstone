using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebButton : MonoBehaviour
{
    // Start is called before the first frame update
    public string url;
    public string method;
    public string statusCode;
    public string signature;
    public string userAgent;
    public string accept;
    public string referer;
    public string cookie;
    public string response;
    void Start()
    {
        if (CompareTag("Trigger"))
        {
            GetComponent<Button>().onClick.AddListener(FireClickToHistory);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireClickToHistory()
    { 
        ProxyHistory.AddHistory(url, method, statusCode, signature, userAgent, accept, referer, cookie, response);
    }
}