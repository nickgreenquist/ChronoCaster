using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * 10);
	}

	void OnTriggerEnter(Collider Collection)
	{
		if (Collection.gameObject.tag == "Player2")
		{
			Collection.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
