using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamara : MonoBehaviour {

    public Transform jugador;
    // Use this for initialization

        //Es lo ultimoq ue se hace
    private void LateUpdate() {
        Vector3 nuevaPosicion = jugador.position;
        nuevaPosicion.y = transform.position.y;
        transform.position= nuevaPosicion;

        transform.rotation = Quaternion.Euler(90F, jugador.eulerAngles.y, 0F);
    
    }
	
}
