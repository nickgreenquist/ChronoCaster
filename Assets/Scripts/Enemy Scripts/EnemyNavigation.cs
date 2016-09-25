using UnityEngine;
using System.Collections;

public class EnemyNavigation : MonoBehaviour {
	
	public Vector3 startPos;
	public Transform target;
	public bool chasing = false;
	NavMeshAgent agent;
	
	// Use this for initialization
	void Awake() 
	{
		agent = GetComponentInParent<NavMeshAgent>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(chasing)
		{
			Follow ();
		}
		else
		{
			ResetPosition();
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			chasing = true;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			chasing = false;
		}
	}
	
	void Follow()
	{
		
		agent.SetDestination(target.position);
	}
	
	void ResetPosition()
	{
		agent.SetDestination(startPos);
		Debug.Log(startPos);
	}
}
