using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class EcualizadorGUI : MonoBehaviour {

    float ancho = 300;
    float alto = 250;
    Rect recArea;
    float x;
    float y;

    private float valorSlider = .5f;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Ej1Menu");
    }


    private void OnGUI()
    {
        PrepararMarco();
    }

    //Pinta le marco de la ventana
    void PrepararMarco()
    {
        x = (Screen.width / 2) - (ancho / 2);
        y = (Screen.height / 2) - (alto / 2);
        recArea = new Rect(x, y, ancho, alto);
        recArea = GUI.Window(1, recArea, PintarVentana, "Ecualizador");
    }

    //Pintara el contenido de la ventana
    void PintarVentana(int id)
    {       
        GUILayout.BeginHorizontal();//Comienzo de pintado
        float valor = 0F;
        for (int i = 0; i < 10; i++)
        {
            valor= valor + 0.1F;
            GUILayout.VerticalSlider(valor,0, 1);
            if (i != 10- 1)//Al ultimo no necesitamos añadir espacios
                GUILayout.FlexibleSpace();//Inserta un espacio entre los elementos
        }

        GUILayout.EndHorizontal();
    }
}
