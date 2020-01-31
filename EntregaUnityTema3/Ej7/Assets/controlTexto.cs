using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTexto : MonoBehaviour {


   
    Vector3 postInit;
    Vector3 pos;
    Vector3 localVerticeUp;
    int i = 1;
    public float _velocidad = 2;
    public Color32 Micolor=Color.yellow;
    public string _textoInicial = "La República Galáctica está sumida en el caos." +
        "\nLos impuestos de las rutas comerciales a los sistemas\n" +
        " estelares exteriores están en \ndisputa.\n" +
        "Esperando resolver el asunto\n" +
        "con un bloqueo de poderosas\n" +
        "naves de guerra, la codiciosa\n" +
        "Federación de Comercio ha\n" +
        "detenido todos los envíos al\n" +
        "pequeño planeta de Naboo.\n";
    public string _texoAniadido;
    public int MiTamanio=25;
    // Use this for initialization
    void Start () {
        GetComponent<TextMesh>().text = _textoInicial;
        postInit = GetComponent<TextMesh>().transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Movimiento de texto
        pos = transform.position;
        localVerticeUp = transform.TransformDirection(Vector3.up);
        pos += localVerticeUp * _velocidad * Time.deltaTime;
       transform.position = pos;

        //cambios del texto
        GetComponent<TextMesh>().fontSize = MiTamanio;
        GetComponent<TextMesh>().color = Micolor;
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<TextMesh>().transform.position = postInit;
            GetComponent<TextMesh>().text += _texoAniadido;
        }

        //Salir del programa
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }


}
