using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]//Etiqueta que nos permite ver los cambios sin realizar la ejecucion
public class GUIDatos : MonoBehaviour {



    string texfieldNombreYApellido = "";
    string texfieldEdad = "";
    static int margenX = 5;
    static int anchoVentana = 365;
    static int altoVentana = 350;
    static int anchoLabel = anchoVentana - 2 * margenX;
    bool pintarMensajeEnviado = false;
    bool edadNocorrecta = false;//cuando la edad no es de tipo numero
    Rect recVentana = new Rect(20, 20, anchoVentana, altoVentana);
    string resultado = "";
    private void Update()
    {
        //GetComponent<AudioSource>().volume = valorSlider;
    }
    private void OnGUI()
    {
        recVentana = GUI.Window(0, recVentana, PintaVentana, "Formulario");
    }

    private void PintaVentana(int id)
    {
        GUIStyle miEstilo = GUI.skin.GetStyle("Label");//Componente al que sobreescribimos el estilo
        miEstilo.fontSize = 14;
        int ancho = 100;
        int alto = 30;
        float x = (recVentana.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        float y = (recVentana.height / 2) - (alto / 2);
        Rect arealabelTitulo1 = new Rect(x - 100, y - 100, ancho + 200, alto + 40);//Titulo nombre y apellidos
        Rect arealabelNomYape = new Rect(x-100, y - 70, ancho+200, alto);//Nombre y apellidos
        Rect arealabelTitulo2 = new Rect(x + 15, y - 30, ancho - 40, alto + 40);//Titulo Edad
        Rect arealabeEdad = new Rect(x+20 , y , ancho-60, alto);//Edad
        Rect areaButn2 = new Rect(x, y +60, ancho, alto);
        Rect areaButn3 = new Rect(x, y+100, ancho, alto);
        Rect areaButn4 = new Rect(1, 2 , ancho-70, alto);
        Rect arealabelInfo = new Rect(x-40, y + 135, ancho+140, alto);//Titulo Edad

        GUI.Label(new Rect(arealabelTitulo1), "Nombre y Apellidos:");
        GUI.Label(new Rect(arealabelTitulo2), "Edad:");
        texfieldNombreYApellido = GUI.TextField(new Rect(arealabelNomYape), texfieldNombreYApellido, 900);
        texfieldEdad = GUI.TextField(new Rect(arealabeEdad), texfieldEdad,3);

        if (texfieldEdad == " ")
            edadNocorrecta = true;

        //Comprobacion de que es numero
        char[] array = texfieldEdad.ToCharArray();
        foreach (char item in array)
        {
            if (!char.IsNumber(item))
            {
                edadNocorrecta = true;//la edad es incorrecta
                break;
            }
            edadNocorrecta = false;//correcto
        }
        //-----Botones guardar y Limpiar-------//
        if (GUI.Button(new Rect(areaButn4), "X"))
        {
            SceneManager.LoadScene("Ej1Menu");
        }

        if (GUI.Button(new Rect(areaButn2), "Enviar"))
        {           
            pintarMensajeEnviado = true;          
        }

        if (GUI.Button(new Rect(areaButn3), "Limpiar"))
        {
            texfieldNombreYApellido = "Nombre y Apellidos:";
            texfieldEdad = "";
            resultado = "";
            pintarMensajeEnviado = false;
        }
        if (pintarMensajeEnviado && !edadNocorrecta)
        {
            resultado = "Enviado ...";
                GUI.Label(new Rect(arealabelInfo), resultado);
        }
        else if (pintarMensajeEnviado && edadNocorrecta)
        {
            resultado = "Error.. la edad no es un número!";
            GUI.Label(new Rect(arealabelInfo), resultado);
        }

        //------------//


        GUI.DragWindow();
    }
}
