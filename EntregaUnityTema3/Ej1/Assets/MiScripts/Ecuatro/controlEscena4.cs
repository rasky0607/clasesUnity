using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//añadido
using UnityEngine.SceneManagement;

public class controlEscena4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Principal");
    }
}
