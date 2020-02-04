using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanzamientoBola : MonoBehaviour {
	Rigidbody rb;
	public Slider sliderFuerza;//muestra el usuario la fuerza con la que va lanzar
	public Text textFuerza;//Especifica la cantidad de fuerza que se muestra en el slider
	public Text textPrecision;
    float fuerzaLanzamiento = 0;
	public Slider sliderPrecision;//Muestra la posibilidad y cantidad de fuerza de torque que se le aplica a la bola
	float fuerzaTorqueVaraible = 0;
	bool subiendoValorTorque = true; //Bandera que indica  al slider de Precision cuando la esta incrementando la fuerzaTorqueVaraible hasta 5 y cuando la esta decrementando hasta-5
	float velocidadDesplazHorizontal = 0.2F;//velocidad de desplazamiento horizontal de la bola
	bool funcionamientoSliderPrecision = true;
	//Puntos de restauracion de bola
	Vector3 PosInicial;
	Quaternion orientacion;
	//Posicion inicial de los bolos
	Vector3 posBolo1;
	Vector3 posBolo2;
	Vector3 posBolo3;
	Vector3 posBolo4;
	Vector3 posBolo5;
    Vector3 posBolo6;
    Vector3 posBolo7;
	Vector3 posBolo8;
	Vector3 posBolo9;
	Vector3 posBolo10;
    //Orientacion de los Bolos
	Quaternion orientBolo1;
	Quaternion orientBolo2;
	Quaternion orientBolo3;
	Quaternion orientBolo4;
	Quaternion orientBolo5;
	Quaternion orientBolo6;
	Quaternion orientBolo7;
	Quaternion orientBolo8;
	Quaternion orientBolo9;
	Quaternion orientBolo10;
	//RigiBody de los bolos
	Rigidbody rbBolo1;
	Rigidbody rbBolo2;
	Rigidbody rbBolo3;
	Rigidbody rbBolo4;
	Rigidbody rbBolo5;
	Rigidbody rbBolo6;
	Rigidbody rbBolo7;
	Rigidbody rbBolo8;
	Rigidbody rbBolo9;
	Rigidbody rbBolo10;
	//Sonido
	public AudioSource sonidoBola;

	//Texto de ayuda
	public GameObject panel;

	void Start () {
		rb = GetComponent<Rigidbody>();
		sliderFuerza.value = fuerzaLanzamiento;
		textFuerza.text = "0";
		sliderPrecision.value = fuerzaTorqueVaraible;
		textPrecision.text = fuerzaTorqueVaraible.ToString();
		PosInicial = transform.position;//guardamos la posicin inicial de la bola
		orientacion = transform.rotation;//Guardamos orientacion de la bola(Para mantener el movimiento lateral de esta antes de lanzar)

        //Guardamos posicion inicial de los bolos
		posBolo1= GameObject.Find("bolo 1").transform.position;
		posBolo2 = GameObject.Find("bolo 2").transform.position;
		posBolo3 = GameObject.Find("bolo 3").transform.position;
		posBolo4 = GameObject.Find("bolo 4").transform.position;
		posBolo5 = GameObject.Find("bolo 5").transform.position;
		posBolo6 = GameObject.Find("bolo 6").transform.position;
		posBolo7 = GameObject.Find("bolo 7").transform.position;
		posBolo8 = GameObject.Find("bolo 8").transform.position;
		posBolo9 = GameObject.Find("bolo 9").transform.position;
		posBolo10 = GameObject.Find("bolo 10").transform.position;
		//Guardamos orientacion
		orientBolo1 = GameObject.Find("bolo 1").transform.rotation;
		orientBolo2 = GameObject.Find("bolo 2").transform.rotation;
		orientBolo3 = GameObject.Find("bolo 3").transform.rotation;
		orientBolo4 = GameObject.Find("bolo 4").transform.rotation;
		orientBolo5 = GameObject.Find("bolo 5").transform.rotation;
		orientBolo6 = GameObject.Find("bolo 6").transform.rotation;
		orientBolo7 = GameObject.Find("bolo 7").transform.rotation;
		orientBolo8 = GameObject.Find("bolo 8").transform.rotation;
		orientBolo9 = GameObject.Find("bolo 9").transform.rotation;
		orientBolo10 = GameObject.Find("bolo 10").transform.rotation;

		//RigiBody de los bolos
		rbBolo1= GameObject.Find("bolo 1").GetComponent<Rigidbody>();
		rbBolo2 = GameObject.Find("bolo 2").GetComponent<Rigidbody>();
		rbBolo3 = GameObject.Find("bolo 3").GetComponent<Rigidbody>();
		rbBolo4 = GameObject.Find("bolo 4").GetComponent<Rigidbody>();
		rbBolo5 = GameObject.Find("bolo 5").GetComponent<Rigidbody>();
		rbBolo6 = GameObject.Find("bolo 6").GetComponent<Rigidbody>();
		rbBolo7 = GameObject.Find("bolo 7").GetComponent<Rigidbody>();
		rbBolo8 = GameObject.Find("bolo 8").GetComponent<Rigidbody>();
		rbBolo9 = GameObject.Find("bolo 9").GetComponent<Rigidbody>();
		rbBolo10 = GameObject.Find("bolo 10").GetComponent<Rigidbody>();
		panel.SetActive(false);


	}

	private void FixedUpdate()
    {
		if (funcionamientoSliderPrecision)
			FuncionamientoSliderPrecision();
	}

    // Update is called once per frame
    void Update () {  

		if (Input.GetKey(KeyCode.Space)) //Mientras la Space este pulsada, acumulamos fuerza
		{
			funcionamientoSliderPrecision = false;//el SliderPrecision, se para
            //cargamos la fuerza hasta un maximo de 10
            if(fuerzaLanzamiento<10)
			    fuerzaLanzamiento++;
			sliderFuerza.value = fuerzaLanzamiento;
			textFuerza.text = sliderFuerza.value.ToString();
			//Recogemos la fuerza de torque al pulsar la tecla espacio que mas tarde aplicaremos al lanzar la bola
			fuerzaTorqueVaraible = sliderPrecision.value;
            
		}

		//Cuando soltamos la Space, lanzamos la bola
		if (Input.GetKeyUp(KeyCode.Space))
		{
            sonidoBola.Play();//activamos sonido
			rb.AddForce(new Vector3(transform.position.x, transform.position.y, transform.position.z * -fuerzaLanzamiento), ForceMode.Impulse);
			rb.AddTorque(new Vector3(transform.position.x, transform.position.y, transform.position.z* fuerzaTorqueVaraible), ForceMode.Impulse);
        }

		//Movimiento de la bola en  direccion horizontal (en eje X)(Solo se puede desplazar la bola mientras este parada)
        if(fuerzaLanzamiento ==0)
		    transform.Translate(Input.GetAxis("Horizontal")*velocidadDesplazHorizontal, 0,0);

        //Si pulsa escape volvemos al menu
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("MenuInicial");
        }
		
	}

	public void FuncionamientoSliderPrecision() {
		if (sliderPrecision.value > -5 && subiendoValorTorque)//Empezamos a decrementar el valor (la bola  va hacia la izquierda) 
		{
			//Solo decrementamos el valor
			sliderPrecision.value--;
			textPrecision.text = sliderPrecision.value.ToString();

			if (sliderPrecision.value == -5)//activamos  bandera, para el cambio de sentido
				subiendoValorTorque = false;//A partir de ahora empieza a subir hasta 5			

		}
		else if (sliderPrecision.value < 5 && !subiendoValorTorque)//Empezamos a incrementar el valor (la bola  va hacia la derecha) 
		{
			//solo aumentamos el valor
			sliderPrecision.value++;
			textPrecision.text = sliderPrecision.value.ToString();

			if (sliderPrecision.value == 5)//activamos bandera para el cambio de sentido
				subiendoValorTorque = true;//A partir de ahora empieza a bajara hasta  -5
		}
	}


    public void Reinicio() {
		//Reiniciamos componentes graficos y varaiblesde fuerza
		sliderFuerza.value = 0;
		sliderPrecision.value = 0;
		fuerzaTorqueVaraible = 0;
		fuerzaLanzamiento = 0;
        //Quitamos la velocidad aplicada al rigibody del objeto para que se pare
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
        //Restablecemos su posicion y orientacion inicial
		transform.position = PosInicial;
		transform.rotation = orientacion;

		//Quitamos velocidad a los bolos
		rbBolo1.velocity = Vector3.zero;
		rbBolo1.angularVelocity = Vector3.zero;
		rbBolo2.velocity = Vector3.zero;
		rbBolo2.angularVelocity = Vector3.zero;
		rbBolo3.velocity = Vector3.zero;
		rbBolo3.angularVelocity = Vector3.zero;
		rbBolo4.velocity = Vector3.zero;
		rbBolo4.angularVelocity = Vector3.zero;
		rbBolo5.velocity = Vector3.zero;
		rbBolo5.angularVelocity = Vector3.zero;
		rbBolo6.velocity = Vector3.zero;
		rbBolo6.angularVelocity = Vector3.zero;
		rbBolo7.velocity = Vector3.zero;
		rbBolo7.angularVelocity = Vector3.zero;
		rbBolo8.velocity = Vector3.zero;
		rbBolo8.angularVelocity = Vector3.zero;
		rbBolo9.velocity = Vector3.zero;
		rbBolo9.angularVelocity = Vector3.zero;
		rbBolo10.velocity = Vector3.zero;
		rbBolo10.angularVelocity = Vector3.zero;

		//Restablecemos posicion de los bolos
		GameObject.Find("bolo 1").transform.position = posBolo1;
		GameObject.Find("bolo 2").transform.position= posBolo2;
		GameObject.Find("bolo 3").transform.position=posBolo3;
		GameObject.Find("bolo 4").transform.position = posBolo4;
		GameObject.Find("bolo 5").transform.position = posBolo5;
		GameObject.Find("bolo 6").transform.position = posBolo6;
		GameObject.Find("bolo 7").transform.position = posBolo7;
		GameObject.Find("bolo 8").transform.position = posBolo8;
		GameObject.Find("bolo 9").transform.position = posBolo9;
		GameObject.Find("bolo 10").transform.position = posBolo10;
		//Restablecemos orientacion de los bolos
		GameObject.Find("bolo 1").transform.rotation= orientBolo1;
		GameObject.Find("bolo 2").transform.rotation = orientBolo2;
		GameObject.Find("bolo 3").transform.rotation = orientBolo3;
		GameObject.Find("bolo 4").transform.rotation = orientBolo4;
		GameObject.Find("bolo 5").transform.rotation = orientBolo5;
		GameObject.Find("bolo 6").transform.rotation = orientBolo6;
		GameObject.Find("bolo 7").transform.rotation = orientBolo7;
		GameObject.Find("bolo 8").transform.rotation = orientBolo8;
		GameObject.Find("bolo 9").transform.rotation = orientBolo9;
		GameObject.Find("bolo 10").transform.rotation = orientBolo10;




	}

    public void Ayuda() {
		panel.SetActive(true);
    }
    //Cuando el usuario hace click en el boton aceptar tras mostrar la ayuda
	public void AceptarAyuda() {
		panel.SetActive(false);
    }

}
