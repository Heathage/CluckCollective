using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject note;
    private string[,] lvOne  = new string[,]{ { "z", "v", "n", "d", "f", "i" }, {"s", "h", "r", "e", "k", "4"} }; //Array of strings that are output by the spawner
    private int est = 1;
    
    void Awake()
    {
        StartCoroutine(Test());
    }


    // Update is called once per frame
    IEnumerator Test()
    {
        for (int i = 0; i < lvOne.Length; i++) // for every item between item equal to 0 and item equal to the length of the lvOne string (in this case 3)
        {
            note.GetComponent<Keypress>().keyType = (lvOne[(est),i]); //Sets the keytype of the note to the current item in the array
            Instantiate(note, gameObject.transform); //instantiates each note
            yield return new WaitForSeconds(1/3f); //Waits for an amount
        }
    }
}