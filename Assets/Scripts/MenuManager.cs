using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Funciona para cargar el primer nivel
    public void LoadLVL1()
    {
        StartCoroutine("Loadlevel1");

    }
  //Funciona para cargar el menu principal
    public void LoadMainMenu()
    {
        StartCoroutine("Loadmenu");
    }

    //Funcion para cargar el menu de victoria
    public void LoadMenuVictoria()
    {
        StartCoroutine("Loadvictoria");
    }
    //Funcion para cargar el menu de derrota
    public void LoadGO()
    {
        StartCoroutine("GameOver");
    }

    public void LoadCredits()
    {
        StartCoroutine("Loadcredits");
    }

    IEnumerator Loadlevel1()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator Loadmenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Loadvictoria()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LevelComplete");
    }
    
    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator Loadcredits()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Credits");
    }
}
