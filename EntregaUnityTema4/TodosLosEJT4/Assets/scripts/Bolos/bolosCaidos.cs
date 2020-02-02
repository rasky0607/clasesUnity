using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bolosCaidos : MonoBehaviour {

	public Image bolo1;
	public Image bolo2;
	public Image bolo3;
	public Image bolo4;
	public Image bolo5;
	public Image bolo6;
	public Image bolo7;
	public Image bolo8;
	public Image bolo9;
	public Image bolo10;
    public AudioSource sonidoBolos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*Sensores:
     * 1ºla cabeza de lso bolos, estan marcadas
     * como isTrigger y tienen un tag que identifican el numero del bolo, asi como en el marcador superior derecho
     2ºUn disparador llamado" DisparadorCaidaBolos" con un rigiBody que no es mas que un cubo al que se le desmarco la propiedad Mesh para que no se vea,
     este es el que tiene asociado este Script "bolosCaidos.cs" ,cuandola cabeza de un bolo sale del colider de este, es identificado por el tag*/
    private void OnTriggerExit(Collider other)
    {
        sonidoBolos.Play();
		switch (other.tag) {
			case "bolo1":
                bolo1.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo2":
				bolo2.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo3":
				bolo3.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo4":
				bolo4.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo5":
				bolo5.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo6":
				bolo6.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo7":
				bolo7.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo8":
				bolo8.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo9":
				bolo9.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo10":
				bolo10.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;		
		}
    }
}
