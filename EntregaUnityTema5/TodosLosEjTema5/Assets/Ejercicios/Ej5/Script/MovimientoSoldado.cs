using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoSoldado : MonoBehaviour {

    public float velocidad = 1F;
    //NavMeshAgent del enemigo para evitar obstaculos
    NavMeshAgent navEnemigo;
    //Patrullar
    public float distanciaPatrulla;
    private float contadorPatrulla;
    Vector3 posInicial; //Posicion Inicial del enemigo al arrancar
    bool movimientoPatrulla;
    // Use this for initialization
    void Start () {
        navEnemigo = GetComponent<NavMeshAgent>();
        distanciaPatrulla = 10F;
        posInicial = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Patrullar());
	}

    IEnumerator Patrullar()
    {
        contadorPatrulla += Time.deltaTime * velocidad;//Tiempo para realizar el movimiento    
        navEnemigo.destination = new Vector3(Mathf.PingPong(contadorPatrulla, distanciaPatrulla) + posInicial.x, posInicial.y, posInicial.z);//Movimiento pingpong
        yield return null;
    }
}
