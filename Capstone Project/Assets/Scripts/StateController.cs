using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public static bool initDone = false;
    
    // Door Statuses
    public static bool meetingRoomDoorOpen;
    public static bool officeBlockDoorOpen;
    public static bool DerekDoorOpen;
    public static bool SandyDoorOpen;

    // Player Position Maintaining (WIP)
    public Rigidbody2D rb;
    public static Vector2 Floor1PlayerPosition;
    public static Vector2 Floor2PlayerPosition;

    // Puzzle Hint Progress
    public static bool receptionNoteFound;
    public static bool showingEncodedText1;
    public static bool meetingRoomNoteFound;
    public static bool showingEncodedText2;

    private void Start() {
        if(initDone == false) {
            initDone = true;
            
            meetingRoomDoorOpen = false;
            officeBlockDoorOpen = false;
            DerekDoorOpen = false;
            SandyDoorOpen = false;

            Floor1PlayerPosition.x = (float)7.0;
            Floor1PlayerPosition.y = (float)-15.75;

            receptionNoteFound = false;
            showingEncodedText1 = false;
            meetingRoomNoteFound = false;
            showingEncodedText2 = false;

            Debug.Log("initial values set");
        }
    }

    //private void Update() {
    //    Floor1PlayerPosition.x = rb.position.x;
    //    Floor1PlayerPosition.y = rb.position.y;
    //}
    
    
}
