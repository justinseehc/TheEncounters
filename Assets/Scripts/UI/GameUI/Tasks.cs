using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public GameObject taskSprite;
    public GameObject taskCanvas;
    public TextMeshPro taskText;
    public string[] taskTexts;
    public int taskIndex = 0;
    private int MaxTask;
    public Animator nextTask;
    private bool NextTask = true;
    // Start is called before the first frame update
    void Start()
    {
        taskIndex = 0;
        taskText.text = taskTexts[taskIndex];
        MaxTask = taskTexts.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TaskComplete()
    {
        if (NextTask == true)
        {
            NextTask = false;
            Debug.Log("Task Complete");
            if (taskIndex + 1 <= MaxTask)
            {
                taskIndex += 1;
                taskCanvas.SetActive(false);
                taskText.text = taskTexts[taskIndex];
            }
            else 
            {
                taskCanvas.SetActive(false);
                taskText.text = "All Tasks Complete";
            }

                StartCoroutine(TaskAnimation());
        }
    }
    IEnumerator TaskAnimation()
    {
        nextTask.SetTrigger("NextTask");
        yield return new WaitForSeconds(1f);
        taskCanvas.SetActive(true);
        NextTask = true;
    }
}
