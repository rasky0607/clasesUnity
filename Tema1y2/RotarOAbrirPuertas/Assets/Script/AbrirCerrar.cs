using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**En este ejemplo veremos como abrir una puerta
 a traves de un objeto vacio llamado bisagra,
 que sera el que rota para abrir la puerta que es hija de la bisagra*/
public class AbrirCerrar : MonoBehaviour {

    public float _velocidadRotacion = 3F;
    bool _puertaCerrada = false;//cuando valga verdad se abre cuando valga false que se cierre
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            _puertaCerrada = true;
        if (Input.GetKeyDown(KeyCode.C))
            _puertaCerrada = false;
        if (_puertaCerrada)
            Abrir();
        else
            Cerrar();

        

    }

    void Abrir() {
        /**Es lo mismo que decir transform directamente que game.transform     
            * Pero cualquier otro componente como Colider necesitamos poner gameObject.componente que queremos usar del objeto
            * ya que el transform es comun a todos, pero el resto no
           */
        //Al usar Lerp la aceleracion de la rotacion es desacelerada, (al final va mas lento)
        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), _velocidadRotacion * Time.deltaTime);
        
    }

    void Cerrar()
    {
        /**Es lo mismo que decir transform directamente que game.transform     
            * Pero cualquier otro componente como Colider necesitamos poner gameObject.componente que queremos usar del objeto
            * ya que el transform es comun a todos, pero el resto no
           */
        //Al usar Lerp la aceleracion de la rotacion es desacelerada, (al final va mas lento)
        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), _velocidadRotacion * Time.deltaTime);
    }
}
