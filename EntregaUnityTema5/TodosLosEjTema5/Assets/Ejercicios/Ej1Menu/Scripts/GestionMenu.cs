using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionMenu : MonoBehaviour {

    string escena;//Este recogera el nombre de la escena a la que se va dirigir al dar a jugar por defecto el Ej2
    public Image imagenDemuestra;
    public Text textExplicativo;
    //Sonido
    public Toggle sonidoOnOff;
    public AudioSource musica;
    public AudioSource sonidoEspada;
    bool activarSonidoEspada = true;
    // Use this for initialization
    void Start() {
        imagenDemuestra.sprite = null;
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/mando");//Accedemos al recurso que va a reproducirse
        escena = null;
        textExplicativo.text = "";
        sonidoOnOff.isOn = true;
        musica.volume = 0.5F;
        sonidoEspada.volume = 0.05F;
    }

    // Update is called once per frame
    void Update() {
        if (sonidoOnOff.isOn)
        {
            musica.volume = 0.5F;
            sonidoEspada.volume = 0.05F;
        }
        if (!sonidoOnOff.isOn)
        {
            musica.volume = 0F;
            sonidoEspada.volume = 0F;
        }

        StartCoroutine("SonidoEspada");
    }
    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator SonidoEspada() {
        if (activarSonidoEspada)//Esta  bandera nos permite quitar vida solo cada 4 segundos de forma continua(de lo contrario solo esperaria 4 segundos la primera vez)
        {
            activarSonidoEspada = false;
            
            yield return new WaitForSeconds(1.2F);//esperamos 1.8 segundos 
            sonidoEspada.Play();
            activarSonidoEspada = true;

        }
    }

    public void Jugar()
    {
        if (escena != null)
            SceneManager.LoadScene(escena);
        else
        {
            textExplicativo.text = "No has selecionado ninguan escena aun!, escoge una y haz click en el boton de Play!";
            imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/mando");//Accedemos al recurso que va a reproducirse
        }
    }

    public void clickEj2()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej2");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej2: En este ejercicio al pulsar la barra espaciadora se pintara un label con un texto.";
        escena = "Ej2";
    }

    public void clickEj3()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej3");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej3:Una esfera y un cubo. La esfera puede ser dirigida con la flecha izquierda y derecha. Al colisionar con el cubo, este cambiara de color y al entrar el raton en su zona. Si hacemos click encima del cubo, bloquearemos el cambio de color.";
        escena = "Ej3";
    }

    public void clickEj4()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej4");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej4:Igual que el Ej3 pero con la variante de que mientras el raton este en la zona del cubo, este no parara de cambiar de color.";
        escena = "Ej4";
    }

    public void clickEj5()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej5");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej5:En este jercicio usamos Time.Scale para detener o reanudar la escena.";
        escena = "Ej5";
    }

    public void clickEj6()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej6");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej6:En este ejercicio usamos los componentes GUI para pintar una ventan que se puede desplazar y nos permite dirigirnos a las escenas 2,3 y 4.";
        escena = "Ej6";
    }

    public void clickEj7()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej7");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej7:Idem Ej6 pero en esta ocasion pintamos un ecualizador con slider.";
        escena = "Ej7";
    }

    public void clickEj8()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej8");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej8:En este ejericio usamos de nuevo los GUI para pintar una ventana a modo de formulario que permite enviar datos del usuario, con la restriccion de que en el campo edad solo permite numeros, de lo contrario se informara de un error.";
        escena = "Ej8";
    }

    public void clickEj9()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej9");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej9:Colision con objetos,pueden sumar o restar de 2 a 5 puntos,tipo cubo 3 y 5 y tipo esfera 2 y 4, colisionar con el mismo tipo de objeto de forma consecutiva restara los puntos de estos, al alternar tipos suma la mitad y cada 3 puntos perdidos se resta una vida al jugador.";
        escena = "Ej9";
    }

    public void clickEj10()
    {
        imagenDemuestra.sprite = Resources.Load<Sprite>("Ej1Menu/img/Ej10");//Accedemos al recurso que va a reproducirse
        textExplicativo.text = "Ej10:En ejercicio al presionar la tecla P colocamos Time.Scale a 1 y con espacio a 0, podemos mover el objeto con la flechas derecha e izquierda y un label nos informara del valor de Time.Scale ";
        escena = "Ej10";
    }

    public void clickEj11()
    {
        imagenDemuestra.sprite=  Resources.Load<Sprite>("Ej1Menu/img/Ej11");//Accedemos al recurso que va a reproducirse
        escena = "Ej11";
        textExplicativo.text = "Ej11: Juego de supervivencia en el que el jugador debe enfrentarse a numerosos enemigos con su arco recorriendo un laberinto con cofres que pueden dotarle de salud extra cuando ha sido dañado, con municion, vida  y tiempo limitados";     
    }



}
