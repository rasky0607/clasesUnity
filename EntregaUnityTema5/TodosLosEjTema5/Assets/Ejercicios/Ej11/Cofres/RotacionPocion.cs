﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPocion : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward+(Vector3.up/4));
	}
}
