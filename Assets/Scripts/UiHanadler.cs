using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHanadler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelCompScreen;
    public GameObject GameOverScreen;

    public void MainMainScreen()
    {
        MainMenu.SetActive(false);
    }
    public void LevelComScreen()
    {
        LevelCompScreen.SetActive(true);   
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true); 
    }

  
}
