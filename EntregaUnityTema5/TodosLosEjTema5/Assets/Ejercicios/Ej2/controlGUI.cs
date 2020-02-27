using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Script asignado a la camra de la escena*/
public class controlGUI : MonoBehaviour {
    private bool pintar = false;
    private int ancho = 300;
    private int alto = 80;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!pintar)
                pintar = true;          
        }

        if (Input.GetKeyDown(KeyCode.Escape))//Volvemos al menu
            SceneManager.LoadScene("Ej1Menu");
    }

    private void OnGUI()
    {
        if (pintar)
        {
            GUIStyle miEstilo = GUI.skin.GetStyle("Label");//Componente al que sobreescribimos el estilo
            GUI.contentColor = Color.blue;
            miEstilo.fontSize = 18;
           
            int ejeXventana = (Screen.width / 2) - (ancho / 2);//la mitad del ancho de la ventana del juego menos la mitad del ancho que queremos de nuestra nueva ventana(Es decir el centro de nuestra ventana)
            int ejeYventana = (Screen.height / 2) - (alto / 2);//la mitad del alto de la ventana

                    
            GUI.Label(new Rect(ejeXventana, ejeYventana, ancho, alto), "Soy un mensaje mostrado con un GUI.Label, pulsa Esc para volver al menu.", miEstilo);
        }
    }
}
