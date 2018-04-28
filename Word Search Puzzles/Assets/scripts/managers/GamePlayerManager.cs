using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GamePlayerManager : MonoBehaviour {

    public static GamePlayerManager Instence { get; private set;}

    public GameObject parentGrid;

    string word;

    public Words words;


    public void Awake()
    {
        if(Instence == null)
        {
            Instence = this;

            ResetWord();
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

 
    public void TryWord()
    {
        Debug.Log("Word to try " + word);
        Debug.Log("Is it a word " + words.IsWord(word));
        ResetWord();
    }

    public void AddLetter(char letter)
    {
        word += letter;
    }

    public void ResetWord()
    {
        Image[] images = parentGrid.GetComponentsInChildren<Image>();
        foreach (Image childImage in images)
        {
            childImage.color = Color.white;
        }
        word = "";
    }

    public void CreateLevel()
    {
        LevelManager.instant.createLevel(words.words.GetRange(0, 2));
        EventSystem.current.currentSelectedGameObject.SetActive(false);
    }
   


}
