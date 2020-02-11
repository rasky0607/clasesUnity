using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Asociado a objeto vacio controlador GUI*/
public class MiGUIScrollView : MonoBehaviour {
    Vector2 posicionScroll = new Vector2(10, 10);
    string contenido = "Este texto es el contenido del ScrollView";
    Rect area1 = new Rect(25, 25, 120, 120);//Area de Scroll
    Rect area2 = new Rect(0, 0, 400, 400);//"Area de contenido" Esto 0 0 , quiere decir que estara en la posicion 0,0 de su contenedor, es decir de su padre, pero no del padre de su padre,es decir, no habra margen.

    private void OnGUI() {
        posicionScroll = GUI.BeginScrollView(area1, posicionScroll, area2);
        //Rec se compone de pos x, poy, alto y ancho
        contenido = GUI.TextArea(new Rect(0, 0, 400, 40),contenido);
        GUI.Button(new Rect(10, 60, 100, 30),"Pulsame");
        GUI.EndScrollView();
    }

}
