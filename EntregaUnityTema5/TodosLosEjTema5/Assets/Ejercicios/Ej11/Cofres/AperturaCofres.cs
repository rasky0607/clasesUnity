using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Este script esta asociado al objeto ZonaAperturaCofres de el objeto padre Cofre, control la anumaciond e apertura de este
 y de la visivilidad de la pocion en caso de ganarla , ademas de i nformar a la clase UI de que se gano una pocion*/
public class AperturaCofres : MonoBehaviour {

    bool pintamosLabelGUI=false;
    public Animator animatorCofre;
    public MeshRenderer pocionSanadora;
    public GameObject cofreCompleto;
    //IMPORTANTE el STATIC ya que de otro modo, aun que reciba el dato de la clase UI del numero de monedas,en la siguiente ejecucion se volvera a inicializar y sera 0, nunca llegara a guardar el dato
    static int numMonedasGanadas=50;//Indica el numero de monedas ganadas por el jugador actualmente lo que determinara la posibilidad de adquirir una pocion de un cofre
    bool pocionEntregada = false;//Para evitar que la rutina corra tanto que de mas de una pocion
    bool calculoProabilidad = false;//Para lo mismo que la anterior, evitar que se calcule varias veces la proabilidad de coger la pocion
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
      
	}

    //Mientras esta dentro
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "jugador")
        {
            //1ºInformamos de que puede pulsar K para abrir
            pintamosLabelGUI = true;//Activamos el pintar el texto informativo para abrir el cofre
            if (Input.GetKey(KeyCode.K))//Abrimos el cofre
            {
                //2º abrimos el cofre (Realizar animacion) si pulso K y activamos el mesh de la pocion
                Debug.Log("Cofre abierto");
                StartCoroutine("AbrirCofre");
                pocionEntregada = false;//La pocion aun no ha sido entregada               
                calculoProabilidad = false;//ARREGLAR CALCULO DE ENTREGAR POCION #############
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Dejamos de pintar el texto informativo para abrir el cofre en cuanto sale el area
        pintamosLabelGUI = false;
    }


    //Pinta el texto informativo para abrir el cofre
    private void OnGUI()
    {
        if (pintamosLabelGUI)
        {
            int ancho = 200;
            int alto = 30;
            int x = (Screen.width / 2) - (ancho / 2);//Cogemos el ancho de  la pantall lo dividimos entre 2 y  le restamos nuestro ancho entre 2
            int y = (Screen.height / 2) - (alto / 2);
            Rect areaLabel = new Rect(x, y - 40, ancho, alto);
            GUI.Label(areaLabel, "Presiona 'K' para abrir el cofre.");            
        }
    }

    /*Inicia la animacion de apertura del cofre espera 2.5 segundos y  mostramos la pocion,
     * el objeto quedara destrudo dos segundos despues e informara a la clase UI de que se gano una pocion*/
    IEnumerator AbrirCofre() {
        animatorCofre.SetBool("abrirCofre", true);//Deja de andar
        yield return new WaitForSeconds(2.5F);//Esperamos 2.5 Segundos
        if (ProabilidadDePocion() &&!calculoProabilidad)//Se gano una pocion
        {
            pocionSanadora.enabled = true;//Mostramos la pocion Activando el rederizado
                                          //Destruimos el cofre
            Destroy(cofreCompleto, 2F);
            if (!pocionEntregada)
            {               
                GameObject.FindGameObjectWithTag("UI").SendMessage("GanarPocion");//Informamos que gano una pocion
                pocionEntregada = true;//Pocion entregada
            }
        }
        else {
            Destroy(cofreCompleto, 2F);//Destruimos el cofre, ya que no se gano una pocion
        }
        
    }

    /*Este metodo determina si en funcion de las monedas del jugador y una aleatoriedad con los Random, gana una pocion o no a mas monedas, mayor proabilidad*/
    private bool ProabilidadDePocion() {
        calculoProabilidad = true;//Calculo de proabilidad realizado
        float valorMaximo = 150F;
        float result = (numMonedasGanadas * 100) / valorMaximo;
        Debug.Log("Proabilidad pociones NumeroMOnedas" + numMonedasGanadas);
        if (numMonedasGanadas == 0)
        {//Si no tiene monedas no gana pociones en  lso cofres
            return false;
        }
        else if (numMonedasGanadas < 10 && numMonedasGanadas > 0)//Si tiene moneda entre esos rangos
        {
            float num = Random.Range(result - 20, valorMaximo / 4);//Entre el resultado y 37,5
            if (num > result)
            {
                //Gana pocion
                Debug.Log("Gana num->" + num + " result->" + result);
                return true;
            }
            else
            {
                //No la gana
                Debug.Log("NO Gana num->" + num + " result->" + result);
                return false;
            }
        }
        else if (numMonedasGanadas < 30 && numMonedasGanadas >= 10)//Si tiene moneda entre esos rangos
        {
            float num = Random.Range(result - 20, valorMaximo / 3);//Entre el resultado y 50
            if (num > result)
            {
                //Gana pocion
                Debug.Log("Gana num->" + num + " result->" + result);
                return true;
            }
            else
            {
                //No la gana
                Debug.Log("NO Gana num->" + num + " result->" + result);
                return false;
            }
        }
        else if (numMonedasGanadas < 70 && numMonedasGanadas >= 30)//Si tiene moneda entre esos rangos
        {
            float num = Random.Range(result - 20, valorMaximo / 2);//Entre el resultado y 75
            if (num > result)
            {
                //Gana pocion
                Debug.Log("Gana num->" + num + " result->" + result);
                return true;
            }
            else
            {
                //No la gana
                Debug.Log("NO Gana num->" + num + " result->" + result);
                return false;
            }
        }
        else if(numMonedasGanadas<=70)
        {
            //Siempre gana pocion
            return true;
        }
        return false;

        
    }

    public void NumeroDeMonedasGanadas(int numero) {
        Debug.Log("Desde el metodo Numero de monedas ganadas num:" + numMonedasGanadas+" numero "+numero);
        numMonedasGanadas = numero;
        Debug.Log("Saliendo del metodo Numero de monedas ganadas num:" + numMonedasGanadas);
    }

   

   
   
}
