﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible()
    {
		Destroy(gameObject);
    }

	void OnCollisionEnter(Collision collision)
    {
		Destroy(gameObject);
	}
}
