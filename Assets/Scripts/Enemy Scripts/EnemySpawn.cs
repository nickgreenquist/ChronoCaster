using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public int timer;
	public int spawnEnemy;
	public GameObject enemy;

	public GameObject spawnSpell;
	public GameObject newSpell;
	public SpellEffect spellEffect;

	public GameObject player;

	public bool spawnSpellReady = false;
	// Use this for initialization
	void Start () {
		timer = 0;
		spawnEnemy = 240;
		player = GameObject.Find("Player");
		spawnSpellReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		float d = Vector3.Distance (this.transform.position, player.transform.position);
		if(d < 25)
		{
			timer++;
		}
		if(timer >= spawnEnemy - 120 && spawnSpellReady)
		{
			newSpell = (GameObject)Instantiate(spawnSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
			spawnSpellReady = false;
		}
		if(timer >= spawnEnemy)
		{
			timer = 0;
			spawnSpellReady = true;
			GameObject newEnemy = (GameObject)Instantiate(enemy, this.transform.position, this.gameObject.transform.rotation);
		}
	}
}
