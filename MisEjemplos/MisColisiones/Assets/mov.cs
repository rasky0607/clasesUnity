using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour {

    float _velocidad = 4.00F;
    float _posX = 0;
    float _posZ = 0;
    const float MAX = 5;
    const float MIN = -5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _posX += Input.GetAxis("Horizontal") * _velocidad * Time.deltaTime;
        _posZ += Input.GetAxis("Vertical") * _velocidad * Time.deltaTime;
        _posX = Mathf.Clamp(_posX, MIN, MAX);
        _posZ = Mathf.Clamp(_posZ, MIN, MAX);
        transform.position = new Vector3(_posX, transform.position.y, _posZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Destroy(other.gameObject);
            Debug.Log("Hola");
        }
    }
}
