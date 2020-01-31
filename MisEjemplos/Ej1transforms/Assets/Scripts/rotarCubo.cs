using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarCubo : MonoBehaviour {

    public float _y = 0;
    public float _x = 0;
    public float _z = 0;
    public float _velocidad = 100F;
    float anguloY=40;
    float anguloZ=20;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //transform.RotateAround(transform.position,Vector3.up,4*Time.deltaTime);
        //transform.Rotate(transform.position, Space.Self);
        //transform.Rotate(Vector3.up,50*Time.deltaTime);

        /*Rotamos el objeto en los angulos indicados,(en este caso sobre el eje Y y el eje Z)
         * En caso de que queramos que la rtoacion se perpetua , debemos incrementar los valores del alguno o angulos sobre el que queremos rotar
         * anguloY++;
         *anguloZ++;
        */
        RotarCubos();
    }

    public void RotarCubos()
    {
        transform.eulerAngles = new Vector3(0, anguloY, anguloZ);
        anguloY++;
        anguloZ++;
    }


}
