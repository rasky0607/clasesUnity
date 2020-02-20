using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script asociado a los pilares llamados (Pillar_Pref) los cuales son como mini tiendas donde optener municion u otros recursos quizas más adelante se vera*/
public class TiendaPillar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jugador")
        {
            
            Debug.Log("ENTREE TOMA YA");
        }
    }
}
