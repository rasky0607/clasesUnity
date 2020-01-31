using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.UI;

/*Script asignado a GameObject Empty Pescador que controla
 * cuando el usuario pesco un pez segun si el Handler del slider (slTemporizador) tiene el color verde o no
 * y los suma al contador de pescado (txtContadorPescado)
 */

public class pescador : MonoBehaviour {

    public Slider _slTemporizador;
    public Image handle;
    public Text _txtContadorPescados;
    public GameObject pesc;
    int _npecesPescados=0;
    bool _teclaArriba = false;

    //Rotacion
    float maximo = 30;
    float minimo = 0;
    float tiempoA = 0.00F;
    //provisional
    bool flag = false;

    // Use this for initialization
    void Start () {
        _txtContadorPescados.text = "Peces pescados: "+_npecesPescados;
        //Desacivamos el slider, para que no pueda ser clicado 
        _slTemporizador.enabled = false;

        //Minimo de rotacion(es decir la posicion inicial de rotate X)
        minimo = transform.rotation.x;
    }
	
	// Update is called once per frame
	void Update () {

        //Al levantar el boton izquierdo del raton(De este modo no suma varios pescados de un solo click)
         _teclaArriba = Input.GetKeyUp(KeyCode.Mouse0);
        if (handle.color == Color.green && _teclaArriba)
        {
            Pescado();
            //MovimientoCania();

            flag = true;//Activar movimiento provisional
        }
        else if (handle.color != Color.green && _teclaArriba && _npecesPescados > 0)//Si falla, se resta 1 pescado
            _txtContadorPescados.text = "Peces pescados: " + _npecesPescados--;
        else
            _teclaArriba = false;



    }

    public void Pescado()
    {
        _txtContadorPescados.text = "Peces pescados: " + _npecesPescados++;

    }

    //Movimiento rotatorio de la caña al pescar POR AQUI!**
    public void MovimientoCania() {
        int nvueltas = 1;
        while (nvueltas <= 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(minimo, maximo, tiempoA));
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
          
        }

        
    }
}
