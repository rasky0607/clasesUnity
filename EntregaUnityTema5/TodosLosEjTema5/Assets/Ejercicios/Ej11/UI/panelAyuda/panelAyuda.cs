using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Este script esta asignado a los paneles de ayuda*/
public class panelAyuda : MonoBehaviour {
    //Por defecto el los paneles de ayuda estan desactivados
    public GameObject panelAyuda1;
    public GameObject panelAyuda2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Muestra el panelAyuda2 o siguiente pagina
    public void SiguientePagAyuda1() {
        panelAyuda1.SetActive(false);
        panelAyuda2.SetActive(true);
    }

    //Pasa del panelAyuda2 al panelAyuda1
    public void AnteriorPagAyuda2()
    {
        panelAyuda1.SetActive(true);
        panelAyuda2.SetActive(false);
    }

    public void SalirPanelAyuda() {
        panelAyuda1.SetActive(false);//Ocultamos el  panelAyuda1 y 2
        panelAyuda2.SetActive(false);
        GameObject.FindGameObjectWithTag("UI").SendMessage("ActivarPintarMenu");//Activamos de nuevo el menu GUI     
    }
}
