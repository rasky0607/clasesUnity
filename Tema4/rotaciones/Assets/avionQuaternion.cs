using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Esta clase hereda de avionEuler y como esta hereda MonoBehaviour , tiene toda la funcionalidad de unity
 En esta clas eno usamos los Vectore3 si no que usamos directamente un Quartenion que hemos creado, para evitar
 el bloqueo que tiene el otro avion con el script avionEuler*/
public class avionQuaternion : avionEuler {

    

    
    protected override void AplicarRotacion()
    {
        Vector3 _rotacionActual = Vector3.zero;
        _rotacionActual.x = _rotadcionEjeX;
        _rotacionActual.y = _rotadcionEjeY;
        _rotacionActual.z = _rotadcionEjeZ;

        Quaternion rotacion = Quaternion.Euler(_rotacionActual * _velocidadRotacion * Time.deltaTime);
        //IMPORTANTE: Sumamos la rotacion actual con la resultante, para obtener el producto
        transform.rotation *= rotacion;

    }

}
