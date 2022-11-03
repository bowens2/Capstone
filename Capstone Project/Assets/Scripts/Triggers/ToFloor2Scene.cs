using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFloor2Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToFloor2()
    {
        SceneManager.LoadSceneAsync("Scenes/Floor 2", LoadSceneMode.Single);
    }
}
