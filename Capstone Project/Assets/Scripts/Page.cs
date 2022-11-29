using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
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
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(FireClickToHistory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireClickToHistory()
    {
        ProxyHistory.AddHistory(url, method, statusCode, signature, userAgent, accept, referer, cookie);
    }
}
