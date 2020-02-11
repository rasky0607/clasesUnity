using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Script de scena2 asoaciado a objeto vacio""  Ejemplo para mostrar control que dsitribuye los GUI automaticamente*/
public class distribucioNAutomaticaGUI : MonoBehaviour {
    public Texture imagen;
    public string texto = "hola caracola";
    public string txtArea = "Aqui podriamos poner mucho texto ya que es para un textArea";
    public bool accion = false;
    public string[] botones = {"uno", "dos", "tres" };
    int botonClick = 0;//identificador boton clicado
    public string txtEtiqueta = "Soy  una etiqueda de GUILayout";
    private void OnGUI() {
        Mostrar();
    }

    void Mostrar() {
        GUILayout.BeginHorizontal();//cambia la distribucion para horizontal por defecto es en vertical
        //GUILayout.BeginArea(new Rect(100, 100, 50, 50));
      
        GUI.color = Color.cyan;
        //Espacio es decir pixeles  segun la distribucion, si esta en vertical,  los mete  de arriba abajo y si es horizontal de izquierda a derecha ya que empieza desde la 0,0
        GUILayout.Space(20);
        GUILayout.Label(txtEtiqueta);
        if (GUILayout.Button("Pulsame"))
            Debug.Log("has pulsado el boton ...");
        if (GUILayout.RepeatButton("Me repito"))
            Debug.Log("Me Me Me Pulsoooo ...");
        texto = GUILayout.TextField(texto);
        txtArea = GUILayout.TextArea(txtArea);
        accion = GUILayout.Toggle(accion, "On/Off");
        botonClick = GUILayout.Toolbar(botonClick, botones);
        txtEtiqueta = "Has pulsado el boton " + botonClick.ToString();
        GUILayout.EndHorizontal();
        //GUILayout.EndArea();
        //Cmabiar horientacion
        // para empezarGUILayout.BeginHorizontal() y  para terminar GUILayout.EndHorizontal();
        //GUILayout.BeginVertical();


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
