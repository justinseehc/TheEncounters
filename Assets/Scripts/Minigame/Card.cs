using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
   [SerializeField] private Image imageIcon;

    public Sprite hiddenIconSprite;
    public Sprite iconSprite;

    public bool isSelected;

    public CardController controller;

    public void OnCardClick()
    {
        controller.SetSelected(this);
    }
    public void SetIconSprite(Sprite sp)
    {
        iconSprite = sp;
    }

    public void Show()
    {
        imageIcon.sprite = iconSprite;
        isSelected = true;
    }

    public void Hide()
    {
        imageIcon.sprite = hiddenIconSprite;
        isSelected = false;
    }
}
