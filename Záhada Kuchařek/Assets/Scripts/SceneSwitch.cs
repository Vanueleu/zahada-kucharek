using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    
    public static string prevScene;
    public static string currentScene;

    SavePlayerPos playerPosData;


    public virtual void Start()
    {

        currentScene = SceneManager.GetActiveScene().name;


        playerPosData = FindObjectOfType<SavePlayerPos>();

    }

    public void SwitchScene(string sceneName)
    {

        playerPosData.PlayerPosSave();
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);

    }

}
