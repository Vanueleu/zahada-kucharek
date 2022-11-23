using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    
    SavePlayerPos playerPosData;


    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }
    
    public void QuitGame()
    {
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene("Main Menu");
    }
}
