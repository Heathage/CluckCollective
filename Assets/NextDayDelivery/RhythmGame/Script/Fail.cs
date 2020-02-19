using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    private int failLevel = 4;
    void OnTriggerEnter2D(Collider2D note) //If the notes collide with a 2D collider
    {
        failLevel -= 1;
        Debug.Log(failLevel);
        if (failLevel == 0)
        {
            Debug.Log("Game Over!");
        }
    }
}