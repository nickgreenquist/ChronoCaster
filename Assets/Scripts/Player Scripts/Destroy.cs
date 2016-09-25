using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public int counter;
	public int duration;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if(counter > duration)
		{
			Destroy(gameObject);
		}
	}
}
