using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {


	int shootCounter = 0;

	public GameObject bullet;

	GameObject player;
	Transform playerTransform;

	Vector3 tempPos;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("PlayerObject");
	}
	
	// Update is called once per frame
	void Update () {
	
		playerTransform = player.transform;
		shootCounter++;
		if(shootCounter > 45)
		{
			shootCounter = 0;
			shoot();
		}

		this.transform.LookAt(playerTransform);
	}

	public void shoot()
	{
		GameObject newBullet = (GameObject)Instantiate( bullet,this.gameObject.transform.position + this.transform.forward  * 3,this.gameObject.transform.rotation);
	}
}
