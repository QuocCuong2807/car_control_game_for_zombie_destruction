using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    /// <summary>
    /// reload first scene
    /// </summary>
    public void LoadFirstScene()
    {
        StartCoroutine(WaitLoadFirstScene());
    }

    //load second scene
    public void LoadSecondSecene() 
    {
        StartCoroutine(WaitLoadSecondScene());
    }

    //load last scene
    public void LoadLastScene() 
    {
        StartCoroutine(WaitToLoadlastScene());
    }

    //load menu ui scene
    public void backToMenu() 
    {
        StartCoroutine (WaitToLoadMenuScene());
    }


    IEnumerator WaitToLoadlastScene() 
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }

    IEnumerator WaitLoadSecondScene()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    IEnumerator WaitLoadFirstScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }


    IEnumerator WaitToLoadMenuScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

}
