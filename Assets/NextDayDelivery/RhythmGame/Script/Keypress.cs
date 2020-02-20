using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMOD;

public class Keypress : MonoBehaviour
{
    public GameObject hit;
    public string keyType;
    
    void Update()
    {
        transform.Translate(-Vector3.right * Time.deltaTime / 2); //Moves each note left slowly
        //int test = GetComponent<StudioGlobalParameterTrigger>().OverrideValue;
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>(); //references the textmeshpro script attatched to the note
        textmeshPro.SetText(keyType); //sets the text attatched to textmesh pro as the key type, which is assigned in the spawner script
    }
    void OnTriggerEnter2D(Collider2D hit) //If the notes collide with a 2D collider
    {
        if (Input.GetKey(keyType)) //and if the input key is equal to the keytype
        {
            Destroy(gameObject); //destroy the note object
        }

        if(hit.CompareTag("RhythmFail"))
        {
            Destroy(gameObject);
        }
    }
}