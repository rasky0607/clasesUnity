using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class movimiento : MonoBehaviour {

    public float velocidadAndar = 1F;
    public float velocidadRotacion = 40F;
    bool pintarLabel = false;
    bool juegoEnPausa = false;
    string label = "Valor: ";   
    // Use this for initialization
    void Start () {

        Time.timeScale = 1;//Velocidad del juego normal   
        label = "Valor: " + 1;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.left);
        //Desplazamiendo del personaje
        /*if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * velocidadAndar * Time.deltaTime);
            
        }*/
        //transform.Translate(Input.GetAxis("Horizontal") * velocidadAndar * Time.deltaTime, 0, 0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime, 0, 0);
           
        }
        if (Input.GetKey(KeyCode.Space))
        {
            juegoEnPausa =true;
            PausarJuego(juegoEnPausa);
        }
        if (Input.GetKey(KeyCode.P))
        {
            juegoEnPausa = false;
            PausarJuego(juegoEnPausa);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Ej1Menu");
            
        }
    }

    private void OnGUI()
    {      

        int ancho = 200;
        int alto = 30;
        int x = (Screen.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
        int y = (Screen.height / 2) - (alto / 2);
        Rect arealabel = new Rect(x, y, ancho, alto+20 );
        GUI.Label(new Rect(arealabel), label);
    }

    public void PausarJuego(bool pausa)
    {
        juegoEnPausa = pausa;
        if (juegoEnPausa)
        {
            Time.timeScale = 0;//Velocidad del juego nula por lo tanto parada
            label = "Valor: " + 0;
        }
        else if (!juegoEnPausa)
        {
            Time.timeScale = 1;//Velocidad del juego normal   
            label = "Valor: " + 1;
        }
    }
}
