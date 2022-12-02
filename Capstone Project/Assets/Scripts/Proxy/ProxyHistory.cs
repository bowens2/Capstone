using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProxyHistory : MonoBehaviour
{
    private static int _count;
    private static List <Text> _urlTexts;
    private static List <Text> _methodTexts;
    private static List <Text> _codeTexts;
    private static InputField _signature;
    private static InputField _userAgent;
    private static InputField _accept;
    private static InputField _referer;
    private static InputField _cookie;
    private static InputField _response;
    private static string _interceptedResponse;
    private static bool _intercept;
    // Use this for initialization
    void Start ()
    {
        _count = 0;
        var allButtons = GetComponentsInChildren<Button>();
        //filtering
        _urlTexts = new List<Text>();
        _methodTexts = new List<Text>();
        _codeTexts = new List<Text>();
        
        foreach (var b in allButtons)
        {
            if (b.CompareTag("history button"))
            {
                // var text = b.GetComponentsInChildren<Text>();
                foreach (var text in b.GetComponentsInChildren<Text>())
                {
                    if (text.CompareTag("url tag"))
                    {
                        _urlTexts.Add(text);
                    }
                    if (text.CompareTag("method tag"))
                    {
                        _methodTexts.Add(text);
                    }
                    if (text.CompareTag("code tag"))
                    {
                        _codeTexts.Add(text);
                    }
                }
            }
        }
        var request = GetComponentsInChildren<Image>();
        foreach (var r in request)
        {
            if (r.CompareTag("user-agent"))
            {
                var userAgentVal = r.GetComponentInChildren<InputField>();
                if (userAgentVal.CompareTag("user-agent value"))
                {
                    _userAgent = userAgentVal;
                }
            }
                    
            if (r.CompareTag("accept"))
            {
                var acceptVal = r.GetComponentInChildren<InputField>();
                if (acceptVal.CompareTag("accept value"))
                {
                    _accept = acceptVal;
                }
            }
                    
            if (r.CompareTag("cookie"))
            {
                var cookieVal = r.GetComponentInChildren<InputField>();
                if (cookieVal.CompareTag("cookie value"))
                {
                    _cookie = cookieVal;
                }
            }
                    
            if (r.CompareTag("referer"))
            {
                var refererVal = r.GetComponentInChildren<InputField>();
                if (refererVal.CompareTag("referer value"))
                {
                    _referer = refererVal;
                }
            }
                    
            if (r.CompareTag("request"))
            {
                var signatureVal = r.GetComponentInChildren<InputField>();
                if (signatureVal.CompareTag("req header value"))
                {
                    _signature = signatureVal;
                }
            }
            
            if (r.CompareTag("response"))
            {
                var responseVal = r.GetComponentInChildren<InputField>();
                if (responseVal.CompareTag("response value"))
                {
                    _response = responseVal;
                }
            }
        }
    }

    public static void AddHistory(string url, string method, string statusCode, string signature, string userAgent, string accept, string referer, string cookie, string response)
    {
        _urlTexts[_count % _urlTexts.Count].text = _count+" "+url;
        _methodTexts[_count % _methodTexts.Count].text = method;
        _codeTexts[_count % _codeTexts.Count].text = statusCode;
        _signature.text = signature;
        _accept.text = accept;
        _userAgent.text = userAgent;
        _referer.text = referer;
        _cookie.text = cookie;
        _interceptedResponse = _intercept? response : _interceptedResponse;
        _response.text = _intercept ? "waiting for send ..." : response;

        _count++;
    }
    
    
    public static void ToggleIntercept()
    {
        _intercept = !_intercept;
    }
    
    public static void Send()
    {
        _intercept = false;
        
        //for demo
        if (_signature.text.Equals("POST www.test.com/Red HTTP/1.1"))
        {
            _interceptedResponse = "{\n\tcolor: RED\n}";
        }

        _response.text = _interceptedResponse;
    }
}
