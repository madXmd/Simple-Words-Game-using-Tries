using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterNode : MonoBehaviour {

    public Text text;
    char letter;

    //Neighbors
    public LetterNode top;
    public LetterNode left;
    public LetterNode buttom;
    public LetterNode right;

    public char Letter
    {
        get
        {
            return letter;
        }

        set
        {
            letter = value;
            text.text = letter.ToString();
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

    public void OnClick()
    {
        GamePlayerManager.Instence.AddLetter(Letter);
        this.GetComponent<Image>().color = Color.red;
    }


}
