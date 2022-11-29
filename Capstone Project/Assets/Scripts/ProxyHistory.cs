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

    private static Text _signature;

    private static Text _userAgent;

    private static Text _accept;

    private static Text _referer;

    private static Text _cookie;
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
                var userAgentVal = r.GetComponentInChildren<Text>();
                if (userAgentVal.CompareTag("user-agent value"))
                {
                    _userAgent = userAgentVal;
                }
            }
                    
            if (r.CompareTag("accept"))
            {
                var acceptVal = r.GetComponentInChildren<Text>();
                if (acceptVal.CompareTag("accept value"))
                {
                    _accept = acceptVal;
                }
            }
                    
            if (r.CompareTag("cookie"))
            {
                var cookieVal = r.GetComponentInChildren<Text>();
                if (cookieVal.CompareTag("cookie value"))
                {
                    _cookie = cookieVal;
                }
            }
                    
            if (r.CompareTag("referer"))
            {
                var refererVal = r.GetComponentInChildren<Text>();
                if (refererVal.CompareTag("referer value"))
                {
                    _referer = refererVal;
                }
            }
                    
            if (r.CompareTag("signature"))
            {
                var signatureVal = r.GetComponentInChildren<Text>();
                if (signatureVal.CompareTag("signature value"))
                {
                    _signature = signatureVal;
                }
            }
        }
    }

    public static void AddHistory(string url, string method, string statusCode, string signature, string userAgent, string accept, string referer, string cookie)
    {
        _urlTexts[_count % _urlTexts.Count].text = url;
        _methodTexts[_count % _methodTexts.Count].text = method;
        _codeTexts[_count % _codeTexts.Count].text = statusCode;
        _signature.text = signature;
        _accept.text = accept;
        _userAgent.text = userAgent;
        _referer.text = referer;
        _cookie.text = cookie;
        
        _count++;
    }
}
