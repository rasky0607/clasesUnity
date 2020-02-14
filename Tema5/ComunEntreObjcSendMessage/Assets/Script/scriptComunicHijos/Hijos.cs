using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script asociado a los objetos vacios que son hijos del objeto llamado Emisor*/
public class Hijos : MonoBehaviour {

    void Accion(string texto) {
        Debug.Log("Soy el hijo " + gameObject.name);
    }
}
