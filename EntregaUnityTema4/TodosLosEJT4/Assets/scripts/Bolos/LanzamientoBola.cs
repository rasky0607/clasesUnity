using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanzamientoBola : MonoBehaviour {
	Rigidbody rb;
	public Slider sliderFuerza;//muestra el usuario la fuerza con la que va lanzar
	public Text textFuerza;//Especifica la cantidad de fuerza que se muestra en el slider
	float fuerzaLanzamiento = 0;
	public Slider sliderPrecision;//Muestra la posibilidad y cantidad de fuerza de torque que se le aplica a la bola
	float fuerzaTorqueVaraible = 0;
	public Text textPrecision;
	bool subiendoValorTorque = true; //Bandera que indica  al slider de Precision cuando la esta incrementando la fuerzaTorqueVaraible hasta 5 y cuando la esta decrementando hasta-5
	float velocidadDesplazHorizontal = 0.2F;//velocidad de desplazamiento horizontal de la bola
	bool funcionamientoSliderPrecision = true;

    //Sonido
    public AudioSource sonidoBola;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
		sliderFuerza.value = fuerzaLanzamiento;
		textFuerza.text = "0";
		sliderPrecision.value = fuerzaTorqueVaraible;
		textPrecision.text = fuerzaTorqueVaraible.ToString();
        
	}
    private void FixedUpdate()
    {
		
	}

    // Update is called once per frame
    void Update () {

        if(funcionamientoSliderPrecision)
		    FuncionamientoSliderPrecision();

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
}
