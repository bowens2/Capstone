using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private static int _count;
    private static List <Text> _texts;

    private static bool _started;
    // Use this for initialization
    void Start ()
    {
        _count = 0;
        var allButtons = GetComponentsInChildren<Button>();
        //filtering
        _texts = new List<Text>();
        foreach (var b in allButtons)
        {
            if (b.CompareTag("history button"))
            {
                _texts.Add(b.GetComponentInChildren<Text>());
            }

            _started = true;
        }
    }

    public static void AddHistory(string url, string method, string statusCode)
    {
        _texts[_count % _texts.Count].text = url + " " + method + " " + statusCode;
        _count++;
    }
    string ResToString (Resolution res){
        return res.width + " x " + res.height;
    }
}
