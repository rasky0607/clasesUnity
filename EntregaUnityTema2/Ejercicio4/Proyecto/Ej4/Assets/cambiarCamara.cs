using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarCamara : MonoBehaviour {
   public Camera camara1= null;
   public Camera camara2 = null;




    // Use this for initialization
    void Start () {
        camara1.enabled = true;
        camara2.enabled = false;


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            camara1.enabled = true;
            camara2.enabled = false; 
        }
        if (Input.GetKeyDown("2"))
        {
            camara1.enabled = false;
            camara2.enabled = true;        
        }
   


    }
}
