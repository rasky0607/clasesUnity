using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Script asociado al cubo*/
public class CambioColor : MonoBehaviour {

    private Color colorInicial;
    public bool ratonEnZona = false;
    private bool colorBloqueado = false;
    public Text textInfo;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        colorInicial = GetComponent<Renderer>().material.color;
        textInfo.text = "Color NO bloqueado!";
        textInfo.color = Color.green;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))//Voler a menu
            SceneManager.LoadScene("Ej1Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!colorBloqueado)
            GetComponent<Renderer>().material.color = Color.blue;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!colorBloqueado)
            GetComponent<Renderer>().material.color = colorInicial;
    }

    private void OnMouseDown()//Click
    {      
        colorBloqueado = !colorBloqueado;//Cada vez que haga click cambiamos al estado contrario
        if (colorBloqueado)
        {
            textInfo.text = "Color bloqueado!";
            textInfo.color = Color.blue;
        }
        else if (!colorBloqueado)
        {
            textInfo.text = "Color NO bloqueado!";
            textInfo.color = Color.green;
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
    
    private void OnMouseExit()
    {
        if (!colorBloqueado)
            GetComponent<Renderer>().material.color = colorInicial;
    }
}
