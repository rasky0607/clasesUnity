using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Este script esta asociado al objeto ZonaAperturaCofres de el objeto padre Cofre, control la anumaciond e apertura de este
 y de la visivilidad de la pocion en caso de ganarla , ademas de i nformar a la clase UI de que se gano una pocion*/
public class AperturaCofres : MonoBehaviour
{

    bool pintamosLabelGUI = false;
    public Animator animatorCofre;
    public MeshRenderer pocionSanadora;
    public GameObject cofreCompleto;
    public AudioSource conseguirPocion;
    //IMPORTANTE el STATIC ya que de otro modo, aun que reciba el dato de la clase UI del numero de monedas,en la siguiente ejecucion se volvera a inicializar y sera 0, nunca llegara a guardar el dato
    static int numMonedasGanadas;//Indica el numero de monedas ganadas por el jugador actualmente lo que determinara la posibilidad de adquirir una pocion de un cofre
    bool pocionEntregada = false;//Para evitar que la rutina corra tanto que de mas de una pocion  
    Coroutine coruAbrirCofre;
    void Start()
    {

        conseguirPocion.clip = null;//NO  asignamos audio, ya que este se asignara en funcion de lo que ocurra en el OnTriggerStay
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Mientras esta dentro
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "jugador")
        {
            //1ºInformamos de que puede pulsar K para abrir
            pintamosLabelGUI = true;//Activamos el pintar el texto informativo para abrir el cofre
            if (Input.GetKey(KeyCode.F))//Abrimos el cofre
            {
                animatorCofre.SetBool("abrirCofre", true);//Abrir cofre
               
                if (ProabilidadDePocion())//Se gano una pocion
                {
                    //2º abrimos el cofre (Realizar animacion) si pulso K y activamos el mesh de la pocion
                    Debug.Log("Cofre abierto");                   
                    coruAbrirCofre = StartCoroutine(AbrirCofre());
                    //pocionEntregada = false;//La pocion aun no ha sido entregada    
                   
                }
                else if(!ProabilidadDePocion() && !pocionSanadora.enabled)//Si pproabilidadDePocion devolvio falso y no se muestra el renderizado de la pocion
                {

                    if (coruAbrirCofre == null)//Si la corrutina es null es por que no se  inicio y si no lo hizo es por que no gano pocion
                    {
                        conseguirPocion.clip = Resources.Load<AudioClip>("Ej11/Sonidos/NoConsigueObjeto");//Accedemos al recurso que va a reproducirse
                       //Debug.Log("SE ve ? " + pocionSanadora.enabled);
                        if (!pocionSanadora.enabled)
                            conseguirPocion.Play();

                        // Debug.Log("SALES POR EL TRIGGER");
                        Destroy(cofreCompleto, 3.5F);
                    }
                    

                }

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
            GUI.Label(areaLabel, "Presiona 'F' para abrir el cofre.");
        }
    }

    /*Inicia la animacion de apertura del cofre espera 2.5 segundos y  mostramos la pocion,
     * el objeto quedara destrudo dos segundos despues e informara a la clase UI de que se gano una pocion*/
    IEnumerator AbrirCofre()
    {
        //animatorCofre.SetBool("abrirCofre", true);//Abrir cofre 
        conseguirPocion.clip = Resources.Load<AudioClip>("Ej11/Sonidos/ConseguirObjeto");//Accedemos al recurso que va a reproducirse
        conseguirPocion.Play();//Reproducimos sonido
        yield return new WaitForSeconds(2.5F);//Esperamos 2.5 Segundos     

        pocionSanadora.enabled = true;//Mostramos la pocion Activando el rederizado
        //Debug.Log("SALES POR EL por CORRUTINA");
        Destroy(cofreCompleto, 2F); //Destruimos el cofre
        if (!pocionEntregada)
        {
            //Debug.Log("GANO! pocionEntregada->" + pocionEntregada);
            GameObject.FindGameObjectWithTag("UI").SendMessage("GanarPocion");//Informamos que gano una pocion
            pocionEntregada = true;//Pocion entregada
        }
    }

    /*Este metodo determina si en funcion de las monedas del jugador y una aleatoriedad con los Random, gana una pocion o no a mas monedas, mayor proabilidad*/
    private bool ProabilidadDePocion()
    {
        float valorMaximo = 150F;
        float result = (numMonedasGanadas * 100) / valorMaximo;
        //Debug.Log("Proabilidad pociones NumeroMOnedas" + numMonedasGanadas);
        if (numMonedasGanadas == 0)
        {//Si no tiene monedas no gana pociones en  lso cofres
            //Debug.Log("NIVEL 0 NO Gana");
            return false;
        }
        else if (numMonedasGanadas < 10 && numMonedasGanadas > 0)//Si tiene moneda entre esos rangos
        {
            float num = Random.Range(result - 65, valorMaximo / 4);//Entre el resultado y 37.5
            //Debug.Log("NIVEL 1 valores entre result->" + (result-30) + "y " + valorMaximo/4 + " ?");
            if (num > (valorMaximo / 4)/2)//Es decir mayor que 18,75
            {
                //Gana pocion
                Debug.Log("NIVEL 1 Gana num->" + num + " es mayor que.. result->" + result + " ?");
                return true;
            }
            else
            {
                //No la gana
                //Debug.Log("NIVEL 1 NO Gana num->" + num + " es mayor que.. result->" + result);
                return false;
            }
        }
        else if (numMonedasGanadas < 30 && numMonedasGanadas >= 10)//Si tiene moneda entre esos rangos
        {
            float num = Random.Range(result - 5, valorMaximo / 3);//Entre el resultado y 50
            Debug.Log("NIVEL 2 valores entre result->" + (result - 30) + "y " + valorMaximo / 3 + " ?");
            if (num > (valorMaximo / 3) /2)//Es decir mayor que 25
            {
                //Gana pocion
                //Debug.Log("NIVEL 2 Gana num->" + num + " es mayor que.. result->" + result);
                return true;
            }
            else
            {
                //No la gana
                Debug.Log("NIVEL 2 NO Gana num->" + num + " es mayor que.. result->" + result);
                return false;
            }
        }
        else if (numMonedasGanadas < 65 && numMonedasGanadas >= 30)//Si tiene moneda entre esos rangos
        {
            float num = Random.Range(result , valorMaximo / 2);//Entre el resultado y 75
            Debug.Log("NIVEL 3 valores entre result->" + (result - 10) + "y " + valorMaximo / 2 + " ?");
            if (num > (valorMaximo / 2) / 2)//Es decir mayor que 37,5
            {
                //Gana pocion
                //Debug.Log("NIVEL 3 Gana num->" + num + " es mayor que.. result->" + result);
                return true;
            }
            else
            {
                //No la gana
                //Debug.Log("NIVEL 3 NO Gana num->" + num + " es mayor que.. result->" + result);
                return false;
            }
        }
        else
        {
            //Debug.Log("NIVEL 4  Gana 100%->");
            //Siempre gana pocion
            return true;
        }
    }

    public void NumeroDeMonedasGanadas(int numero)
    {
        Debug.Log("Desde el metodo Numero de monedas ganadas num:" + numMonedasGanadas + " numero " + numero);
        numMonedasGanadas = numero;
        Debug.Log("Saliendo del metodo Numero de monedas ganadas num:" + numMonedasGanadas);
    }





}
