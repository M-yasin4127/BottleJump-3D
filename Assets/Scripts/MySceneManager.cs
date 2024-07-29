using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
 
    public void loadScene1()
    {
        Debug.Log("Reloading Scene");
        SceneManager.LoadScene("Level1");
    }
}
