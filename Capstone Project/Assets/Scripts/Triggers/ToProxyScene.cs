using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToProxyScene : MonoBehaviour
{
    // Update is called once per frame
    public void ToProxy()
    {
        SceneManager.LoadSceneAsync("Scenes/ProxyDemo", LoadSceneMode.Single);

    }
}
