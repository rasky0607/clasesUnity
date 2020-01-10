using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorAgujero : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(other,1);//El uno es el tiempo
    }

}
