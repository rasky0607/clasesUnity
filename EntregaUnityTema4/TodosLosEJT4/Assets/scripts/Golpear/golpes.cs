using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class golpes : MonoBehaviour {

	Rigidbody rbSphera;
	float fuerzaDeEmpuje=3.0F;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject obj6;
	//x min 6 max 6
	//z min 6 max 6
	float maxposXyZ = 6F;
	float minposXyZ = -6F;
	//panel Ayuda
	public GameObject panel;
	List<Color> colores = new List<Color>();
	// Use this for initialization
	void Start () {
		panel.SetActive(false);
		rbSphera = GetComponent<Rigidbody>();//guardamos el rigiBody de la sphera
        //Colores que se pueden aplicar a los objc al chocar o dejar de chocar
		colores.Add(Color.black);
		colores.Add(Color.green);
		colores.Add(Color.red);
		colores.Add(Color.gray);
		colores.Add(Color.blue);
		colores.Add(Color.cyan);
		colores.Add(Color.magenta);

		CambiarPosDeObjetos();
	}
	
	// Update is called once per frame
	void Update () {

		//Adelante/atras
		if (Input.GetAxis("Horizontal") > 0)
		{
			rbSphera.AddForce(new Vector3(transform.position.x * Input.GetAxis("Horizontal")+fuerzaDeEmpuje, transform.position.y, transform.position.z), ForceMode.Force);
			Debug.Log("Pase por aqui");
		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			rbSphera.AddForce(new Vector3(transform.position.x * Input.GetAxis("Horizontal") - fuerzaDeEmpuje, transform.position.y, transform.position.z), ForceMode.Force);
			Debug.Log("Pase por aqui");
		}
        //Hacia los lados
		if (Input.GetAxis("Vertical") > 0)
		{
			rbSphera.AddForce(new Vector3(transform.position.x , transform.position.y, transform.position.z * Input.GetAxis("Vertical") + fuerzaDeEmpuje), ForceMode.Force);
			Debug.Log("Pase por aqui");
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			rbSphera.AddForce(new Vector3(transform.position.x , transform.position.y, transform.position.z * Input.GetAxis("Vertical") - fuerzaDeEmpuje), ForceMode.Force);
			Debug.Log("Pase por aqui");
		}

		//Volver al menu principal
		if (Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("MenuInicial");

	}

	public void CambiarPosDeObjetos() {
		obj1.transform.position = new Vector3(Random.Range(maxposXyZ, minposXyZ), obj1.transform.position.y, Random.Range(maxposXyZ, minposXyZ));
		obj2.transform.position = new Vector3(Random.Range(maxposXyZ, minposXyZ), obj2.transform.position.y, Random.Range(maxposXyZ, minposXyZ));
		obj3.transform.position = new Vector3(Random.Range(maxposXyZ, minposXyZ), obj3.transform.position.y, Random.Range(maxposXyZ, minposXyZ));
		obj4.transform.position = new Vector3(Random.Range(maxposXyZ, minposXyZ), obj4.transform.position.y, Random.Range(maxposXyZ, minposXyZ));
		obj5.transform.position = new Vector3(Random.Range(maxposXyZ, minposXyZ), obj5.transform.position.y, Random.Range(maxposXyZ, minposXyZ));
		obj6.transform.position = new Vector3(Random.Range(maxposXyZ, minposXyZ), obj6.transform.position.y, Random.Range(maxposXyZ, minposXyZ));
	}

	public void ClickAyuda() {
		panel.SetActive(true);//Mostramos el panel
    }

	public void ClickAceptarAyuda()
	{
		panel.SetActive(false);//Ocultamos el panel
	}

	private void OnCollisionEnter(Collision item)
    {
		
		if (item.gameObject.tag != "Player" && item.gameObject.tag != "Respawn")
		{
			int n = Random.Range(0, colores.Count - 1);
			Debug.Log(item.gameObject.name + " ha de colisionar");
			item.gameObject.GetComponent<Renderer>().material.color = colores[n];
		}
	}

    private void OnCollisionExit(Collision item)
    {
		
		if (item.gameObject.tag != "Player" && item.gameObject.tag != "Respawn")
		{
			int n = Random.Range(0, colores.Count - 1);
			Debug.Log(item.gameObject.name +" dejo de colisionar");
			item.gameObject.GetComponent<Renderer>().material.color = colores[n];
		}
	}


}
