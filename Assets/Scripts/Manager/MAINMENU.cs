using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    public void ChangeScene(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }
}
