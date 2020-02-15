using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {
	public Gun gun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
    {
		gun.UpgradeGun();
		SoundManager.Instance.PlayOneShot(SoundManager.Instance.powerUpPickup);
		Destroy(gameObject);
    }
}
