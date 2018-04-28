using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriesNode  {

    Dictionary<char, TriesNode> map;

    char[] alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    string value;

    bool isWord;
    

    public TriesNode()
    {
        Map = new Dictionary<char, TriesNode>();
        foreach(char alpha in alphas){
            Map.Add(alpha, null);
        }
    }

    public string Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
        }
    }

    public Dictionary<char, TriesNode> Map
    {
        get
        {
            return map;
        }

        set
        {
            map = value;
        }
    }

    public bool IsWord
    {
        get
        {
            return isWord;
        }

        set
        {
            isWord = value;
        }
    }
}
