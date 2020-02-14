using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour {
    public GameObject cubo;
    public float _ratioTiempoDeLanzamiento = 0.5F;

	// Use this for initialization
	void Start () {
        StartCoroutine(LanzarCubos());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Corrutina
    IEnumerator LanzarCubos() {
        //Se va lanza siempre
        /*Al ser una corutina, lanza un cubo, sale de la corutina y en el siguiente fragme , vuelve a lanzar otro cubo*/
        while (true) {
            Instantiate(cubo, transform.position,Random.rotation);//Crea el cubo
            yield return new WaitForSeconds(_ratioTiempoDeLanzamiento);//Esperate durante este tiempo antes de realizar la siguiente vuelta
        }
       
    }
}
