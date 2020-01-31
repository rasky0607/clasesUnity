using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lanzarMoneda : MonoBehaviour {

	public Text puntuacion;
	int puntos = 0;
    static int puntua =-1;// -1 no puntua , 1 si puntua
	// Use this for initialization
	void Start () {
		puntuacion.text = "Puntos: " + puntos;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {

		if (puntua == -1)
		{
			puntua = 1;
		}
		
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Cruz")
		{
			if (puntua == 1)
			{
				puntos += 2;
				//sumamos puntos
				puntuacion.text = "puntos: " + puntos;
				puntua = -1;
			}
		}

		if (other.tag == "Cara")
		{
			if (puntua == 1)
			{
				puntos -= 1;
				//sumamos puntos
				puntuacion.text = "puntos: " + puntos;
				puntua = -1;
			}
		}
	}
}
