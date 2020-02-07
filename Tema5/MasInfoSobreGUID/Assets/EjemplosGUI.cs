using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Ejemplo2 Elementos GUI, Script asociado a la camara*/
public class EjemplosGUI : MonoBehaviour {
    public GUIStyle estilo; //estilo por defecto

    public int x = 10;
    public int y = 10;
    public int ancho = 200;
    public int alto = 30;
    public string texto="Hola caracola";

    //Variable para TextFile
    string texto2 = "";
    //boton con da una textura que vemos cuando es pulsado
    public Texture icono;//para añadir un icono a un boton de la toolbar
    //variable para toogle
    Boolean activado=false;
    //Variable  toolbar
    string[] botones = { "uno", "dos", "tres" };
    int botonPulsado=0;//es decir el primero esta selecionado,por que este vale 0
   
    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}

    /*Ejemplo2 elementos GUI*/
   private void OnGUI()
    {
        //Indicamos el rectangulo donde va a pintarse el GUI

        //aañadiendo un  label
        Rect _area = new Rect(x, y, ancho, alto);
        GUI.color = Color.white;
        GUI.Label(_area, "Soy un label",estilo);
        //Añadiendo un boton
        Rect areaButn = new Rect(x, y + 15, ancho, alto);
        if (GUI.Button(areaButn,icono,"pulsame"))//boton con da una textura
            Debug.Log("Me has pulsado");

        //Añadir un tooltip
        Rect areaButn2 = new Rect(x, y + 60, ancho, alto);
        Rect areaToolTip= new Rect(x+120, y + 60, ancho+20, alto+20);
        GUI.Button(areaButn2, new GUIContent("Boton 2", "Mensaje del tooltip"));//creamos el boton que va tener toolTio y indicamos el mensaje de su tooltip
        GUI.Label(areaToolTip, GUI.tooltip);//Creamos el ToolTip

        //Boton de repeticion
        Rect areaButn3 = new Rect(x, y + 95, ancho, alto);
        if (GUI.RepeatButton(areaButn3, "Me repito"))
            Debug.Log("Estoy repitiendome");

        //TextField PENDIENTE
        Rect _areaTF = new Rect(x, y+150, ancho, alto);
        int maxNumcaracter = 60;
       //Importante no inicializar la variable texto junto al TexField string texto = ""; hacerlo fuera, ya que este va muy rapido y lo cambia
        GUI.color = Color.white;
        //El parametro texto que recibe este metodo es el mismo que devuelve por que es constante, es decir.. podemos indicarle un texto en su parametro y el metodo devolvera el mismo
        texto2 = GUI.TextField(_areaTF, texto2, maxNumcaracter);//si  no se le indica.. es todo lo que el permita..     
        Debug.Log(texto2);

        //Tooogle
        Rect _areaToogle = new Rect(x+400, y-10 , ancho, alto);
       activado = GUI.Toggle(_areaToogle, activado, "Apaga la luz");
        GameObject.Find("Directional Light").GetComponent<Light>().enabled=activado;//Apagamos encendemos la luz

        //ToolBar
        Rect areaToolBar = new Rect(x+220, y + 15, ancho, alto);
        botonPulsado = GUI.Toolbar(areaToolBar, botonPulsado, botones);
        Debug.Log("ToolBar: boton pulsado--> " + botonPulsado.ToString());

    }

  
}
