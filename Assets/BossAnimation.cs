using UnityEngine;
using System.Collections;

public class BossAnimation : MonoBehaviour {

	public GameObject player;
	public Animator anim;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance(player.transform.position, this.transform.position);
		anim.SetFloat("Distance",dist);
	}
}
