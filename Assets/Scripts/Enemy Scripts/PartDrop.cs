using UnityEngine;
using System.Collections;

public class PartDrop : MonoBehaviour {

	//player script to keep track of upgrades
	public GameObject player;
	public PlayerExp playerExp;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerObject");
		playerExp = player.GetComponent<PlayerExp>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//delete upgrade once walked over
	void OnTriggerEnter(Collider Collection)
	{
		if(Collection.gameObject.tag == "Player")
		{			
			Destroy(gameObject);
			playerExp.parts++;
		}
	}
}