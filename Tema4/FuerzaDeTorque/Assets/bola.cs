using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script aplicado a la bola para aplicarle una fuerza de torque*/
public class bola : MonoBehaviour {

    public float _fuerzaTorque=50F;
    Vector3 _aplicarFuerza;

    public float _fuerzaImpulso = 10F;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*El valor va ser positivo o negativo, segun la tecla que se pulse,
         * ya que Horizontaldevuelve 1 o -1 segun que tecla es pulsada si felcha izqu o ferecha*/
        _aplicarFuerza = Vector3.up * _fuerzaTorque * Time.deltaTime*Input.GetAxis("Horizontal");
        //Accede al componente del rigibody y aplicamos la fuerza de torque
        GetComponent<Rigidbody>().AddTorque(_aplicarFuerza, ForceMode.Force);

  

        //Posicionar un objeto con el componente Rigibody usando su metodo position
        if (Input.GetKey(KeyCode.Space))
        {
           
                //_fuerzaImpulso += 20;
                Debug.Log("PULSADO! = " + _fuerzaImpulso+20);
            

        }
        /*if (!Input.GetKeyDown(KeyCode.Space))
            Lanzar();*/
        Debug.Log("FUERA");
    }

    public void Lanzar() {
        //Nota: GetButtonDown devuelve verdad o falso segun si se pulso y GetAxis 0 1 o -1 segun si se pulso, no se pulso o si se pulso  dercha o izquierda
        //Fuerza de impulso "Aplicamos una fuerza de impulso sobre el eje Z
        if (Input.GetButtonDown("Vertical"))
            GetComponent<Rigidbody>().AddForce(Vector3.forward * _fuerzaImpulso * Time.deltaTime, ForceMode.Impulse);
    }
}
