using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject note;

    private string[][] lvOne = new string[][] { new[] { "z", "v", "n", "d", "f", "i" },
        new[] { "s", "h", "r", "e", "k", }, 
        new[] { "s", "h", "r", "e", "k", "2" },
        new[] { "s", "h", "r", "e", "k", "3" }, 
        new[] { "s", "h", "r", "e", "k", "4" } }; //A multidimentional string array that's output by the spawner. The new[] before each array allows them to be of any length.


    public int level; //Must be replaced with an int that actually represents the level number

    void Awake()
    {
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
    }

    IEnumerator LevelTiming() //Lanuches a time sensitive function
    {
        for (int i = 0; i < lvOne[(level)].Length; i++) // for every item between item equal to 0 and item equal to the length of the lvOne string (in this case 3)
        {
            note.GetComponent<Keypress>().keyType = (lvOne[(level)][i]); //Sets the keytype of the note to the current item in the array
            Instantiate(note, gameObject.transform); //instantiates each note
            yield return new WaitForSeconds(1 / 3f); //Waits for an amount
        }
    }
}