using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform launchPosition;
	private AudioSource audioSource;
	public bool isUpgraded;
	public float upgradeTime = 10.0f;
	private float currentTime;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime > upgradeTime && isUpgraded)
        {
			isUpgraded = false;
        }
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
		Rigidbody bullet = createBullet();
		//Direction is determined by the transform of the object to which this script is attached - page 83.
		bullet.velocity = transform.parent.forward * 100;
		if (isUpgraded)
        {
			Rigidbody bullet2 = createBullet();
			bullet2.velocity = (transform.right + transform.forward / 0.5f) * 100;
			Rigidbody bullet3 = createBullet();
			bullet3.velocity = ((transform.right * -1) + transform.forward / 0.5f) * 100;
		}
		if (isUpgraded)
        {
			audioSource.PlayOneShot(SoundManager.Instance.upgradedGunFire);
		}
        else
        {
			audioSource.PlayOneShot(SoundManager.Instance.gunFire);
		}
    }

	public void UpgradeGun()
    {
		isUpgraded = true;
		currentTime = 0;
    }

	private Rigidbody createBullet()
    {
		GameObject bullet = Instantiate(bulletPrefab) as GameObject;
		bullet.transform.position = launchPosition.position;
		return bullet.GetComponent<Rigidbody>();
	}
}
