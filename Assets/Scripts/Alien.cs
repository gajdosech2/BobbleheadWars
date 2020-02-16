using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Alien : MonoBehaviour {
	public Transform target;
	private NavMeshAgent agent;
	public float navigationUpdate;
	private float navigationTime = 0;
	public UnityEvent OnDestroy;

	public Rigidbody head;
	public bool isAlive = true;

	private DeathParticles deathParticles;

	public DeathParticles GetDeathParticles()
    {
		if (deathParticles == null)
        {
			deathParticles = GetComponentInChildren<DeathParticles>();
        }
		return deathParticles;
    }

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && isAlive)
        {
			navigationTime += Time.deltaTime;
			if (navigationTime > navigationUpdate)
            {
				agent.destination = target.position;
				navigationTime = 0;
            }
		}
	}

	void OnTriggerEnter(Collider other)
    {
		if (isAlive)
        {
			Die();
			SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
		}
    }

	public void Die()
    {
		isAlive = false;
		head.GetComponent<Animator>().enabled = false;
		head.isKinematic = false;
		head.useGravity = true;
		head.GetComponent<SphereCollider>().enabled = true;
		head.gameObject.transform.parent = null;

		Vector3 position = head.transform.position;
		position[1] = 13;
		head.transform.position = position;

		head.velocity = new Vector3(0, 26.0f, 3.0f);

		if (deathParticles)
        {
			deathParticles.transform.parent = null;
			position = deathParticles.transform.position;
			position[1] = 13;
			deathParticles.transform.position = position;
			deathParticles.Activate();
        }

		OnDestroy.Invoke();
		OnDestroy.RemoveAllListeners();
		head.GetComponent<SelfDestruct>().Initiate();
		Destroy(gameObject);
    }
}
