using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Este script pretende rotar el angulo de un cilidro
     */
public class RotarAngulo : MonoBehaviour {
    public float _anguloIni = 0.0F;
    public float _anguloFin=100.0F;
    float _angulo = 00.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Devuelve un valor para el angulo que queremos dar al objeto
        //si ponesmo _anguloFin++ para que aumente en cada ejecucion del update el angulo final y no pare de rotar
        _angulo = Mathf.LerpAngle(_anguloIni, _anguloFin, Time.time);
        //Se lo pasamos el transfor y le damos solo el  valor a Y,ya que ueremos que rote en Y
        //Obcion1 de cambiar el angulo para que rote
        transform.eulerAngles = new Vector3(0,_angulo,0);
        //Obcion2 de cambiar el angulo para que rote
        //transform.rotation = Quaternion.Euler(0, _angulo, 0);
        //Rotacion continua

    }
}
