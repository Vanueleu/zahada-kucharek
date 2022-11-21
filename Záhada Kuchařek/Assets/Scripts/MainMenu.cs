using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        SceneManager.LoadScene("MAIN");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MAIN");
    }
}
