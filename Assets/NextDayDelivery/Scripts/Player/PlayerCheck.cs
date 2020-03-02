using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private void Update()
    {
        if(player == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
