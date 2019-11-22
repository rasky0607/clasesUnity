using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Objeto que rota "en toeria sobre si mismo "*/
public class rotando : MonoBehaviour {

    Vector3 _velocidadRotacion;
	// Use this for initialization
	void Start () {
        _velocidadRotacion = new Vector3(0.33F, 0.33F, 0.33F);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(_velocidadRotacion);
	}
}
