using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Asociado al objeto vacio "controladorGUI" , ejemplo de deteccion cuando se ha clicado en un boton  usando la propiedad CHANGED  y eejemplo de estilo*/
public class MiGUIWhidtChanged : MonoBehaviour {

    int botonClick = 0;//identificador boton clicado
    string[] listadoBotones = { "uno", "dos", "tres" };
    public GUIStyle estilos;
    public GUISkin tiposDeControl;
    private void OnGUI() {
        GUI.skin = tiposDeControl;
        //Lo que muestra
        Rect area = new Rect(50, 10, 400, 30);
        botonClick = GUI.Toolbar(area, botonClick, listadoBotones);
        //Detectamos que ha pasado
        if(GUI.changed)//Cuando algo ha cambiado
        {
            Debug.Log("has hecho click...");
            switch (botonClick)
            {
                case 0:
                    Debug.Log("Boton "+botonClick);
                    break;
                case 1:
                    Debug.Log("Boton " + botonClick);
                    break;
                case 2:
                    Debug.Log("Boton " + botonClick);
                    break;
            }
          

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
