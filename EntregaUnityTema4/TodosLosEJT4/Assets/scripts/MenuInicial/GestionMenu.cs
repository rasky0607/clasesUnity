using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GestionMenu : MonoBehaviour {


	public void clickBtnBillar()
    {
        SceneManager.LoadScene("billar");
    }
    public void clickBtnCyF()
    {
        SceneManager.LoadScene("cinematicaYfisica");
    }
    public void clickBtnGolpear()
    {
        SceneManager.LoadScene("golpear");
    }
    public void clickBtnLaberinto()
    {
        SceneManager.LoadScene("laberinto");
    }
    public void clickBtnRadar()
    {
        SceneManager.LoadScene("radar");
    }
    public void clickBtnBolos()
    {
        SceneManager.LoadScene("bolos");
    }
    public void clickBtnSalir()
    {
        Application.Quit();
    }


}
