using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tries  {

    TriesNode root;

    public Tries()
    {
        root = new TriesNode();
    }

    public bool IsWord(string word)
    {
        word = word.ToLower().Trim();
        TriesNode curr = root;
        bool found =false;
        foreach(char alpha in word.ToCharArray())
        {
            found = curr.Map.TryGetValue(alpha, out curr);
            if (!found)
                return false;
        }
        return found && curr != null && curr.IsWord; 
    }

    public void AddWord(string word)
    {
        word = word.ToLower().Trim();
        TriesNode curr = root;
        TriesNode tempNode;

        foreach (char alpha in word.ToCharArray())
        {
            curr.Map.TryGetValue(alpha, out tempNode);
            if (tempNode == null)
            {
                tempNode = new TriesNode();
                curr.Map.Add(alpha, tempNode);
            }
            curr = tempNode;
        }
        curr.Value = word;
        curr.IsWord = true;
    }


}
