using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCaeserScene : MonoBehaviour
{
    public Transform player;
    bool closeEnough;
    public float detectionRange = 1.0f;

    // Update is called once per frame
    void Update()
    {
        closeEnough = false;

        if(Vector3.Distance(player.position, transform.position) <= detectionRange){
            closeEnough = true;
        }
        if(closeEnough && Input.GetKeyDown(KeyCode.F)) {
            SceneManager.LoadSceneAsync("Scenes/CaesarScene", LoadSceneMode.Single);
        }
    }
}
