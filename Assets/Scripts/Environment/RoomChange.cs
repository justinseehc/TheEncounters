using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    private CharacterInput characterInput;
    [Header("Room TeleportPad")]
    public GameObject currentTeleportPad;
    public GameObject newTeleportPad;

    [Header("Room")]
    public GameObject currentRoom;
    public GameObject newRoom;

    [Header("Loading Screen")]
    public GameObject loadingScreen;
    public TextMeshPro loadingWords;

    [Header("Player")]
    public GameObject player;


    
    public void ChangeRoom()
    {   
        newRoom.SetActive(true);
        player.SetActive(false);
        StartCoroutine(LoadingScreen()); 
    }

    IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);
        loadingWords.text = "Loading Room: " + newRoom.name;
        yield return new WaitForSeconds(1f);
        
        EndLoadingScreen();

    }

    public void EndLoadingScreen()
    {
        loadingScreen.SetActive(false);
        player.SetActive(true);
        player.transform.position = new Vector2(newTeleportPad.transform.position.x, newTeleportPad.transform.position.y + 0.15f);
        currentRoom.SetActive(false);
    }
}
