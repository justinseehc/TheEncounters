using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [Header("Character")]
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;

    [Header("Room")]
    private RoomChange roomChange;
    public GameObject prompt;
    private bool canChangeRoom;

    [Header("Test")]
    public Tasks Tasks;
    
    public void Start()
    {
        anim.SetBool("Right", false);
        anim.SetBool("Left", false);
        anim.SetBool("Up", false);
        anim.SetBool("Down", false);
        anim.SetBool("Idle", false);

    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat( "X" , movement.x);
        anim.SetFloat("Y", movement.y);

        if (canChangeRoom && Input.GetKeyDown(KeyCode.T))
        {
            roomChange.ChangeRoom();
        }
        if (canChangeRoom && Input.GetKeyDown(KeyCode.Y)) 
        {
            Tasks.TaskComplete();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;
        //AnimateChar();
    }

    // ROOM CHANGE
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TeleportPad"))
        {
            prompt.SetActive(true);
            roomChange = collision.gameObject.GetComponent<RoomChange>();
            canChangeRoom = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TeleportPad"))
        {
            prompt.SetActive(false);
            canChangeRoom = false;
        }
    }

    // ANIMATION
    //void AnimateChar()
    //{

    //    if (movement.x > 0)
    //    {
    //        anim.SetBool("Right", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Right", false);
    //    }
    //    if (movement.x < 0)
    //    {
    //        anim.SetBool("Left", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Left", false);
    //    }
    //    if (movement.y > 0)
    //    {
    //        anim.SetBool("Up", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Up", false);
    //    }
    //    if (movement.y < 0)
    //    {
    //        anim.SetBool("Down", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("Down", false);
    //    }

    //    if (movement.x != 0 || movement.y != 0) anim.SetBool("Idle", false);
    //    else anim.SetBool("Idle", true);
    //}
}
