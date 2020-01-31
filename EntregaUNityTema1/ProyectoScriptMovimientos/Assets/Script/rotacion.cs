using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour {
 
    Quaternion _q1 = new Quaternion(0, 0, 0, 0);
    Quaternion _q2 = Quaternion.identity;//Es lo  mismo que crearlo a (0,0,0,0) como el de arriba
    //Operadores:
    //* multiplica la rotacion por otra, multiplicando cada uno de sus componente rotacion 1 la x por la rotacion2 la x etc..
    //== compara con cada  uno de sus componentes

    //Apunta a objeto grafico que tiene un transfor
    /*Ver variables  que puedo utilizar de un objeto en un inspector le indicamos que es public el GameObject
     * Esto hara aprecer en el inspector junto al compoinente del script una variable llamada "objeto",si arrastramos aqui un componente,
     * tendremos todas las variables de ese objeto
     * y dentro de nuestro  nuvo objeto  public GameObject objeto; apareceran los campos del inspector como propiedades
    **/
    public GameObject objeto;

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Aqui hacemos referencia al transfor de el objeto)
        transform.LookAt(objeto.transform);
	}
}
