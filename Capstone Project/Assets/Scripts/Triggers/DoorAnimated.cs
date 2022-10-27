using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
    public Animator animator;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        animator.SetBool("Open", true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    public void CloseDoor() {
        animator.SetBool("Open", false);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
