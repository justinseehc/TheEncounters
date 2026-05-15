using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : MonoBehaviour
{

    public GameObject pauseUI;
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
