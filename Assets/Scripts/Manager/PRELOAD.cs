using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PRELOAD : MonoBehaviour
{
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene("MAIN_MENU");
    }
}
