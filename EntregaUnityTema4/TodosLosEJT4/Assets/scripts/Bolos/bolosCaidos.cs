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
	// Use this for initialization
	void Start () {
		bolo1 = GameObject.Find("ImageBolo1").GetComponent<Image>();
		/*bolo1.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo2.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo3.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo4.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo5.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo6.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo7.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo8.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo9.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen
		bolo10.sprite = Resources.Load<Sprite>("puntacion/boloPuntuacion");//Cargamos la imagen*/

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
		Debug.Log("AQUI TOY");
		switch (other.tag) {
			case "bolo1":
				Debug.Log("Bolo 1 CAIDO!");
                
                bolo1.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo2":
				Debug.Log("Bolo 2 CAIDO!");
				bolo2.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo3":
				Debug.Log("Bolo 3 CAIDO!");
				bolo3.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo4":
				Debug.Log("Bolo 4 CAIDO!");
				bolo4.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo5":
				Debug.Log("Bolo 5 CAIDO!");
				bolo5.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo6":
				Debug.Log("Bolo 6 CAIDO!");
				bolo6.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo7":
				Debug.Log("Bolo 7 CAIDO!");
				bolo7.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo8":
				Debug.Log("Bolo 8 CAIDO!");
				bolo8.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo9":
				Debug.Log("Bolo 9 CAIDO!");
				bolo9.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;
			case "bolo10":
				Debug.Log("Bolo 10 CAIDO!");
				bolo10.sprite = Resources.Load<Sprite>("aspa");//Cargamos la imagen
				break;		
		}
    }
}
