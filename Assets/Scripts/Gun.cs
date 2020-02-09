using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform launchPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
			if (!IsInvoking("fireBullet"))
            {
				InvokeRepeating("fireBullet", 0f, 0.2f);
            }
        }
		if (Input.GetMouseButtonUp(0))
        {
			CancelInvoke("fireBullet");
        }
	}

	void fireBullet()
    {
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;
		bullet.transform.position = launchPosition.position;
		//Direction is determined by the transform of the object to which this script is attached - page 83.
		bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 100;
    }
}
