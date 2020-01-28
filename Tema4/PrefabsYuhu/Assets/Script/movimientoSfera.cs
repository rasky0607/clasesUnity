using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asociado a la esfera de la escena 3

public class movimientoSfera : MonoBehaviour {

    public float fuerzaEmpuje;
    public float fuerzaEmpujeSalto;
    private Rigidbody rb;
    private bool _lanzado;
    public float fuerzaRotacion;
    public GameObject objetoACopiar;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        _lanzado = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !_lanzado)
        {
            //rb.AddForce(Vector3.forward * fuerzaEmpuje, ForceMode.Impulse);
            _lanzado = true;
        }

        if (rb.angularVelocity.magnitude < 0.7F)
            _lanzado = false;

        if (Input.GetKeyDown(KeyCode.S))
        {
            //rb.AddForce(Vector3.up * fuerzaEmpujeSalto, ForceMode.Impulse);
            //Crear copìas de prefabs en ejecucion:
            GameObject _copia = Instantiate(objetoACopiar);
            _copia.transform.position=new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            _copia.GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaEmpujeSalto, ForceMode.Impulse);
            _copia.GetComponent<Rigidbody>().AddTorque(new Vector3(33F,33F,33F) * fuerzaRotacion, ForceMode.Impulse);
            //Destruye la copia a los 0.5 segundos
            Destroy(_copia, 0.5F);

        }



    }
}
