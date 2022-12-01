using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1Interact : MonoBehaviour
{

    public GameObject NoteText;
    public Transform player;

    bool closeEnough;
    public float detectionRange = 1.0f;
    bool textActive = false;

    void Start() {
        NoteText.gameObject.SetActive(false);
        textActive = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        closeEnough = false;

        if(Vector3.Distance(player.position, transform.position) <= detectionRange){
            closeEnough = true;
        }
        if(closeEnough && Input.GetKeyDown(KeyCode.F) && !textActive) {
            StateController.receptionNoteFound = true;
            NoteText.gameObject.SetActive(true);
            textActive = true;
        }
        else if(closeEnough && Input.GetKeyDown(KeyCode.F) && textActive) {
            NoteText.gameObject.SetActive(false);
            textActive = false;
        }
    }
}
