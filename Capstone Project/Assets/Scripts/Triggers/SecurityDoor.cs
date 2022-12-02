using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecurityDoor : MonoBehaviour
{

    [SerializeField] private DoorAnimated door;
    public Transform player;

    public float detectionRange = 3.0f;
    bool closeEnough;
    bool doorOpen;

    
    // Update is called once per frame
    void Update()
    {
        doorOpen = door.animator.GetBool("Open");
        closeEnough = false;

        if(Vector3.Distance(player.position, transform.position) <= detectionRange){
            if(StateController.securityDoorOpen == true) {
                closeEnough = true;
            } else {
                SceneManager.LoadSceneAsync("Scenes/SecurityDoorScene");
            }
            
        }
        if(closeEnough && Input.GetKeyDown(KeyCode.F) && !doorOpen) {
            door.OpenDoor();
            Debug.Log("opening door");
        }
        if(closeEnough && Input.GetKeyDown(KeyCode.F) && doorOpen) {
            door.CloseDoor();
            Debug.Log("closing door");
        }
    }
}
