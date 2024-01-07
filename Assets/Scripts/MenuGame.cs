using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    
    public void startGame() 
    {
        SceneManager.LoadSceneAsync(1);
    }
   
    public void QuitGame() 
    {
        Application.Quit();
    }
}
