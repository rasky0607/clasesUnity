using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTexto : MonoBehaviour {

    string _texto = "La República Galáctica está sumida en el caos." +
        "\nLos impuestos de las rutas comerciales a los sistemas\n" +
        " estelares exteriores están en \ndisputa.\n" +
        "Esperando resolver el asunto\n" +
        "con un bloqueo de poderosas\n" +
        "naves de guerra, la codiciosa\n" +
        "Federación de Comercio ha\n" +
        "detenido todos los envíos al\n" +
        "pequeño planeta de Naboo.\n";
   
    public float _velocidad = 2;
    Vector3 postInit;
    Vector3 pos;
    Vector3 localVerticeUp;
    int i = 1;
    // Use this for initialization
    void Start () {
        GetComponent<TextMesh>().text = _texto;
        postInit = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        localVerticeUp = transform.TransformDirection(Vector3.up);
        pos += localVerticeUp * _velocidad * Time.deltaTime;
        transform.position = pos;

    }

    //Siempre se ejecuta este metodo de forma automatica.
    void OnGUI()
    {
        Debug.Log("-----Ejecucion----" + i);
        i++;
        //Posiciones relativas ala pntalla respecto a la izquierda
        Rect pos = new Rect(20, 10, 150, 40);
        Rect pos1 = new Rect(20, 60, 150, 40);
        if (GUI.Button(pos, "On/Off")) {

            if (_velocidad != 0)
                _velocidad = 0;
            else
            {
                _velocidad = 2;
                //Recoloco el texto a su posicion inicial
                transform.position = postInit;
            }
        }

        if (GUI.Button(pos1, "Invertir"))
        {
            //Invertimos el scroll
            _velocidad = -2;
        }
    }
}
