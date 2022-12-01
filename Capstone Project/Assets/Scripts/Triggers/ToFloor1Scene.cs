using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFloor1Scene : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 position;

    // Start is called before the first frame update
    public void ToFloor1()
    {
        SceneManager.LoadSceneAsync("Scenes/Floor 1", LoadSceneMode.Single);
        
        
        position.x = StateController.Floor1PlayerPosition.x;
        position.y = StateController.Floor1PlayerPosition.y;

        rb.MovePosition(position);
        Debug.Log("player position change");
    }
}
