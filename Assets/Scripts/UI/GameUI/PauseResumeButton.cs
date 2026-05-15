using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PauseResumeButton : PauseGameButton
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] buttonSprites;
    private BoxCollider2D boxCollider;
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        spriteRenderer.sprite = buttonSprites[0];
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void OnMouseEnter()
    {
        StartCoroutine(HoverAnimation());
        Debug.Log("Mouse Enter");
    }

    IEnumerator HoverAnimation()
    {
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.sprite = buttonSprites[i];

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public void OnMouseExit()
    {
        spriteRenderer.sprite = buttonSprites[0];
    }

    public void OnMouseDown()
    {
       isPaused = !isPaused;
       pauseUI.SetActive(false);
       Time.timeScale = 1f;
    }
}