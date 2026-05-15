using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;

    private List<Sprite> spritePairs;

    Card firstSelected;
    Card secondselected;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
    }
    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            // adding sprite 2 times to make a pair for the cards
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        ShuffleSprites(spritePairs);
    }

    void CreateCards()
    {
        for(int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if(card.isSelected == false)
        {
            card.Show();

            if (firstSelected == null)
            {
                firstSelected = card;
                return;
            }

            if (secondselected == null)
            {
                secondselected = card;
                StartCoroutine(CheckMatching(firstSelected, secondselected));
                firstSelected = null;
                secondselected = null;
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);
        if(a.iconSprite == b.iconSprite)
        {
            // Matched
        }
        else
        {
            // flip them back
            a.Hide();
            b.Hide();
        }
    }

     // Method to shuffle a list of sprites
     void ShuffleSprites(List<Sprite> spriteList)
     {
      for (int i = spriteList.Count - 1; i > 0; i--)
      {
         int randomIndex = Random.Range(0, i + 1);

         // Swap the elements at i and randomIndex
         Sprite temp = spriteList[i];
         spriteList[i] = spriteList[randomIndex];
         spriteList[randomIndex] = temp;
      }
     }
}
