using UnityEngine;
using System.Collections;

public class EnemyShoot2 : MonoBehaviour {
	
	
	int shootCounter = 0;
	
	public GameObject bullet;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		shootCounter++;
		if(shootCounter > 20)
		{
			shootCounter = 0;
			shoot();
		}
	}
	
	public void shoot()
	{
		GameObject newBullet = (GameObject)Instantiate( bullet,this.gameObject.transform.position + this.transform.forward  * 3,this.gameObject.transform.rotation);
	}
}
