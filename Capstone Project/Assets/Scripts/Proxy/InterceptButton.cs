using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterceptButton : MonoBehaviour
{
    void Start()
    {
        if (CompareTag("intercept"))
        {
            GetComponent<Button>().onClick.AddListener(ProxyHistory.ToggleIntercept);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}