using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="test")]
public class Words : ScriptableObject {

    public List<string> words;
    Tries trie;

    public void Init()
    {
        trie = new Tries();
        foreach (string word in words)
        {
            trie.AddWord(word);
        }
    }

    public bool IsWord(string word)
    {
        return trie.IsWord(word);
    }

 

    

}
