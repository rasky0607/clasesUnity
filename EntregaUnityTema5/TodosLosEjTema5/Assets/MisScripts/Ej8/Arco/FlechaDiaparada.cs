using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDiaparada : MonoBehaviour {
    //lanzamiento flecha
    Rigidbody rbFlecha;
    float fuerza = 20F;
    Vector3 fuerzaAdelante;
    float cargaDeFuerza = 1;
  

   

    // Use this for initialization
    void Start () {
        rbFlecha = gameObject.GetComponent<Rigidbody>();//Recogemos el rigibody de la flecha
        LanzarFlecha();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LanzarFlecha()
    {      
        fuerzaAdelante = Vector3.forward * fuerza * Time.deltaTime * 5;//Cntrl Izq o btn Iz raton, es decir (0)
        rbFlecha.AddForce(fuerzaAdelante, ForceMode.Impulse);
        //rbFlecha.useGravity = true;

        //Prueba flecha clonada
        rbFlecha.AddForce(fuerzaAdelante, ForceMode.Impulse);
    }

}
