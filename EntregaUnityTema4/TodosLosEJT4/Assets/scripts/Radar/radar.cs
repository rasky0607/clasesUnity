using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class radar : MonoBehaviour {

	Vector3 _direccionTorre;
	Vector3 _direccionBase;//La direccion
	int _alcance = 500;
	public GameObject torre;
	public GameObject baseTorre;
	RaycastHit[] _objetosDetectadosTorre;
	RaycastHit[] _objetosDetectadosBaseTorre;

	// Use this for initialization
	void Start() {
		_direccionTorre = torre.transform.TransformDirection(Vector3.left * _alcance);
		_direccionBase = baseTorre.transform.TransformDirection(Vector3.right * _alcance);
		
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("MenuInicial");
		if (_objetosDetectadosBaseTorre != null)
		{
			foreach (RaycastHit item in _objetosDetectadosBaseTorre)
			{
				Debug.Log("DETECTADO: " + " Distancia: " + item.distance.ToString() + " Nombre: " + item.collider.name.ToString());
			}
		}
		if (_objetosDetectadosTorre != null)
		{
			foreach (RaycastHit item in _objetosDetectadosTorre)//Descipcion de objeto
			{
				Debug.Log("DETECTADO: " + " Distancia: " + item.distance.ToString() + " Nombre: " + item.collider.name.ToString());
			}
		}
		Girar();
        //Vuelta al menu inicials
		

	}

	public void Girar() {
		torre.transform.Rotate(new Vector3(0, 1, 0));
		baseTorre.transform.Rotate(new Vector3(0, 1, 0));
		//Giramos el rayo con el objeto
		_direccionTorre = torre.transform.TransformDirection(Vector3.left * _alcance);
		_direccionBase = baseTorre.transform.TransformDirection(Vector3.right * _alcance);
		_objetosDetectadosTorre = Physics.RaycastAll(torre.transform.position, _direccionTorre);//Detecta un de objetos
		_objetosDetectadosBaseTorre = Physics.RaycastAll(baseTorre.transform.position, _direccionBase);//Detecta un de objetos

	}

	

    //Pinta el rayo en el juego
    private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawRay(torre.transform.position, _direccionTorre);
		Gizmos.DrawRay(baseTorre.transform.position, _direccionBase);
	}
}
