using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script asociado al Cubo
/**Se pretende accder al componente del cubo desde el codigo, el cual no tendra  la gravedad activa en su rigibody en principio
 para luego acceder a este componente y activarsela desde codigo*/
/**Tambien se trata el ejemplo de coleciones publicas*/
public class AccederComponente : MonoBehaviour {

    Vector3 rotacion = Vector3.left;
    float velocidad = 5F;
    //Ejmplo coleciones publicas a estas podremos inicializarlas desde el inspector indicando el tamaño de la coleccion y pasandole los objetos en los cual se almacenaran en esta coleccion
    public Light[] luces;
    public List<GameObject> objetos;
    public Transform[] camaras;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotar();
	}

    void Rotar() {
        //1º forma de acceder al componente a traves de su tipo en este caos (Transform)
        GetComponent<Transform>().Rotate(rotacion * velocidad);//Rotar

        if (Input.GetMouseButtonDown(0))//Boton raon izq
            velocidad++;//aumentamos velocidad de rotacion
        if (Input.GetMouseButtonDown(1))//boton derecho del raton
            velocidad--;//disminuimos velocidad de rotacion

        //2º forma de acceder al componente ,Sin utilizar el metodo generico indicandole el tipo, es decir "  GetComponent<Transform>()"
        if (Input.GetKeyDown(KeyCode.Space))//si pulsa el espacio
        {
            ((Rigidbody)GetComponent(typeof(Rigidbody))).useGravity = true;//activa la gravedad
            velocidad = 0;//paramos la velocidad
            GetComponent<Renderer>().material.color = Color.red;//cambia el material
        }

        
    }
}
