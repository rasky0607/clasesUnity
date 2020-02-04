using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**Este script, pretende pintaruna linea, entre los enemigos o cubos en este caso mas cercanos y el jugador o capsula, */
/**Otro ejemplo sobre este proyecto, es la de localizar los hijos de un objeto padre*/
[ExecuteInEditMode]//esta etiqueta nos permite  ejecutar el script en el modo diseño, no en la ventana de game, para ver los gizmos, sin tener que ejecutarlo
public class enemigoGizmo : MonoBehaviour {
    public float range = 2F;//radio 2 es decir diametro 4 ,este es utilizado para marcar un gizmo redondo al rededor del enemigo marcando su zona de influencia.
    List<GameObject> _enemigos=null;
    public Transform _padre;

	// Use this for initialization
	void Start () {
		//optener todos los enemigos
        _enemigos = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemigo"));//recoger la lista de todos los objetos que tiene el tag "enemigo"

        //Esto demuestra que un transform padre esta formado por una coleccion de los transform de todos sus hijos
        foreach (Transform item in _padre.transform)
        {
            Debug.Log("Localizado: "+item.gameObject.name);
        }

	}
	
	// Update is called once per frame
	void Update () {
       
        //transform.Find("objetosEnemigos"); //encuentra el primer hijo  de este padre

        

    }

    private void OnDrawGizmos() {
        if (_enemigos == null || _enemigos.Count == 0)
            return;

        Gizmos.color = Color.blue;
        float distanciaActual = float.MaxValue;//distancia maxima que hay
        GameObject _enemigocercano = null;

        //comprobamos la distancia
        foreach (var item in _enemigos)
        {
            float distancia = Vector3.Distance(transform.position, item.transform.position); //distancia entre el enemigo y el jugador

            if (distancia < distanciaActual)
            {
                distanciaActual = distancia;
                _enemigocercano = item;
            }

           
        }

        if (_enemigocercano != null)//si es distinto d enull, dibujamos
        {
            Gizmos.DrawLine(transform.position, _enemigocercano.transform.position);
        }

    }

}
