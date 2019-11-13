using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.UI;

public class rellenaDropdown : MonoBehaviour {
    
	// Use this for initialization
    List<string> listSemana= new List<string>{"Lunes","Martes","Miercoles","Jueves", "Viernes" };

    public Dropdown _dropDown;
	void Start () {
        _dropDown.options.Clear();
        _dropDown.AddOptions(listSemana);
        _dropDown.value = 2;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
