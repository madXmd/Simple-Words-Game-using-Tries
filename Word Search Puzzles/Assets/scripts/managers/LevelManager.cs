using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static LevelManager instant { get; private set; }

    public void Awake()
    {
        if (instant == null)
        {
            instant = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }


    public GameObject letterPrefab;
    public GameObject parentGrid;


    public void createLevel(List<string> words)
    {
        int numberOfLetters = 0;
        int longestWordAlpaCount = 0;
        foreach(string word in words)
        {
            int wordSize = word.Length;
            numberOfLetters += wordSize;
            if(longestWordAlpaCount < wordSize)
            {
                longestWordAlpaCount = wordSize;
            }
        }

        float gridWidth = parentGrid.GetComponent<RectTransform>().sizeDelta.y;

        int col = numberOfLetters -1;

        col += numberOfLetters / longestWordAlpaCount;
        col += (numberOfLetters % longestWordAlpaCount > 0) ? 1 : 0;

        GridLayoutGroup gridLayout = parentGrid.GetComponent<GridLayoutGroup>();
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;

        gridLayout.constraintCount = col;

        float width = (gridWidth / col);
        gridLayout.cellSize = new Vector2(width, width);

        col *= col;

        int alpaCounter = 0;
        int wordCounter = 0;

        for (int i = 0; i < col; i++)
        {
            GameObject temp = Instantiate(letterPrefab);
            temp.transform.SetParent(parentGrid.transform);
            temp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            string word = words[wordCounter];
            temp.GetComponent<LetterNode>().Letter = word[alpaCounter];
            alpaCounter++;
            if (alpaCounter == word.Length)
            {
                wordCounter++;
                alpaCounter = 0;
                if (wordCounter == words.Count)
                    wordCounter = 0;
            }
        }

    }
}
