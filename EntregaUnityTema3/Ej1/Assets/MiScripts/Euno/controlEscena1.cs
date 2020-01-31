using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*Script asignado al UI panel llamado Menu
 * Este script pretende dar movimiento al slider que contiene
 * e indicar cuando es posible pescar un pez(cuando esta el handler verde) y cuando no(color marron)**/
public class controlEscena1 : MonoBehaviour {

    public Slider _slTemporizador;
    bool _llegoAlFinal = false;
    public Image handle;
    Color _colorOriginal;
    public Text _txtContadorPescados;

    //Randoms que añaden aleatoriedad al momento en el que se puede pescar(Cuando esta verde)
    int valorMinimo;
    int valorMaximo;
    int valorDeRecorridoValido;

    //Variables para Pescar
    public GameObject pescador;
    int _npecesPescados = 0;
    bool _teclaArriba = false;

    //Rotacion
    float maximo = 30;
    float minimo = 0;
    float tiempoA = 0.00F;
    //Sonido al pescar
    public AudioSource SonidoPezPescado;



    // Use this for initialization
    void Start () {      
        //Color original del hanle, es decir el circulito del slider
        _colorOriginal = handle.color;

        _txtContadorPescados.text = "Peces pescados: " + _npecesPescados;
        //Desacivamos el slider, para que no pueda ser clicado 
        _slTemporizador.enabled = false;
        
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Principal");
      
        FuncionamientoSlTemporizador();

        //Pescar------------------------------------
        //Al levantar el boton izquierdo del raton(De este modo no suma varios pescados de un solo click)
        _teclaArriba = Input.GetKeyUp(KeyCode.Mouse0);
        if (handle.color == Color.green && _teclaArriba)
        {
            Pescar();
            StartCoroutine(MovimientoCania());
            SonidoPezPescado.Play();

        }
        else if (handle.color != Color.green && _teclaArriba && _npecesPescados > 0)//Si falla, se resta 1 pescado
            _txtContadorPescados.text = "Peces pescados: " + _npecesPescados--;
        else
            _teclaArriba = false;
        //------------------------------------------------

   

    }

    /*Metodo que hace funcionar la barra de slider aumentando y siminuiendo su value y dandole colores a el Handle*/
    public void FuncionamientoSlTemporizador()
    {
        /*Randoms para determina el valor minimo y maximo para cuando se puede pescar un pez
       y un tercer Random para indicar si durante el recorrido de el handler por el slider se podra alguna vez verde o no(dando mas aliatoriedad)*/
        valorMinimo = Random.Range(1, 25);
        valorMaximo = Random.Range(valorMinimo + 10, 51);
        valorDeRecorridoValido = Random.Range(1, 15);

        /*Si el valor del slider Temporizador es menor que 50 y aun no llego al final de la barra es decir: (llegoAlFinal--> false)  aumenta su value
    Si el valor del slider Temporizador es menor o igual a 50 y llego al final de la barra es decir: (llegoAlFinal--> true)  disminuye su value
    Es necesario usar la bandera, ya que de este modo podemos pregunta si el valor es igual o menor a 50 y decrementar value cuando esta esta a true,
    pues sin ella, en cuanto bajara a 40, se incremntaria de nuevo por culpa del primer if en el cual se pregunta si value es menor a 50*/
        if (_slTemporizador.value < 50 && !_llegoAlFinal)
        {
            _slTemporizador.value++;
            if (_slTemporizador.value == 50)//Llego al final, cambio de bandera
                _llegoAlFinal = true;
        }
        else if (_slTemporizador.value <= 50 && _llegoAlFinal)
        {
            _slTemporizador.value--;
            if (_slTemporizador.value == 1)//Llego al final, cambio de bandera
                _llegoAlFinal = false;
        }
        CambioHandlerDecolor();       
    }

    /*Cambia el color del Handle segun si se encuentra entre unos valores  y minimos y maximos*/
    public void CambioHandlerDecolor() {
        //Si el valor valorDeRecorridoValido  es 1, se puede pescar, si no el handler no estara verde en todo el recorrido
        if (valorDeRecorridoValido == 1)
        {
            //Cambiar color de handler segun si esta dentro del valor indicado correcto(en este caso se conseguira pez, si no , no
            if (_slTemporizador.value > valorMinimo && _slTemporizador.value < valorMaximo)
                handle.color = Color.green;
            else
                handle.color = _colorOriginal;
        }
    }


    public void Pescar()
    {
        _txtContadorPescados.text = "Peces pescados: " + _npecesPescados++;

    }

    //Movimiento rotatorio de la caña al pescar hacia arriba y hacia abajo
    /*
     * CotRutinas:
     * Este metodo ha sido utilizado con lo que se conoce como CotRutina
     * que no es mas que la muestra del estado de los objetos cuando han sufrido algun cambio en el siguiente fotograma o vuelta realizada en el Update
     de forma que para la ejecucion de la  CotRutina una vez se realizo una vuelta de esta, se mostrara el nuevo estado del objeto en el Update y luego se volvera a ejecutar
     dicha CotRutina, de este modo iremos viendo poco a poco los cambios realizado en el objeto(Como una animacion),
     en lugar de verlos de golpe en la ejecucion de cada fragme es decir de cada vuelta del Update()*/
    public IEnumerator MovimientoCania()
    {
        int nvueltas = 1;
        while (nvueltas <= 2)
        {
           pescador.transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(minimo, maximo, tiempoA));
            tiempoA += 0.25F * Time.deltaTime;
            Debug.Log("minimo -->" + minimo + "\n maximo--> " + maximo);
            if (tiempoA > 1)
            {
                float temp = maximo;
                maximo = minimo;
                minimo = temp;
                tiempoA = 0.0F;
                nvueltas++;
                
            }
            yield return null;

        }
      
    }


}
