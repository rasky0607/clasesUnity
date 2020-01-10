using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**Asociado al cubo sensor*/
public class ActivarSensor : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Debug.Log("Te pilé");
        if (other.gameObject.name == "Esfera")
        {
            other.gameObject.transform.position=new Vector3(0,0.5F, 0);other.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
