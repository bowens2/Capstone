using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFloor1Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToFloor1()
    {
        SceneManager.LoadSceneAsync("Scenes/Floor 1", LoadSceneMode.Single);
    }
}
