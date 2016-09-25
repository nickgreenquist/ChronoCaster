using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float basicDamage = 5.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	/*
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player2")
		{
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(basicDamage);
		}
	}
	*/
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player2")
		{
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(basicDamage);
		}
	}

}
