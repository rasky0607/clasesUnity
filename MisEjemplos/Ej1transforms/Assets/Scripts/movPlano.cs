using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlano : MonoBehaviour {
    //Mover hacia los lados/adelante/atras el plano con un maximo de rango(Clamp)
    const float MAX =10;
    const float MIN= -10;//Importante este menos en el min.., ya que si lo colocamos en el max.. se vuelve majara(aun no se exatamente por que)

    float _velocidad =8F;
    float posX=0.0F;
    float posZ= 0.0F;


    // Use this for initialization
    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {


        //Mover plano con las teclas de los cursores
            posX += Input.GetAxis("Horizontal") * _velocidad * Time.deltaTime;
            posZ += Input.GetAxis("Vertical") * _velocidad * Time.deltaTime;

            //controlamos que se mueva en unos limites 
            posX = Mathf.Clamp(posX, MIN, MAX);
            posZ = Mathf.Clamp(posZ, MIN, MAX);

            transform.position=  new Vector3(posX, transform.position.y, posZ);
      
    }
}
