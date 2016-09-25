using UnityEngine;
using System.Collections;

public class SpellEffect : MonoBehaviour {

	public bool fire;
	public bool ice;
	public bool lightning;
	public bool heal;
	public bool levelUp;
	public bool tele;
	public bool tele2;
	public bool tracker;

	//heal offset y
	public float healOffset;

	//spells hitting enemies?
	public bool hitIce;
	public bool hitLight;

	//how long are spells active
	public bool active;
	public int duration;
	public int dTimer;

	//fireball speed
	public int Speed = 50;

	//helper position vector for updating movement
	public Vector3 spellP;

	//player gameObject so we can use its position to keep spells centered
	public GameObject player;
	public GameObject playerContainer;

	//object for melee
	public GameObject melee;

	//for exp from killing enemy
	public PlayerExp playerExp;
	public PlayerHealth playerHealth;
	public PlayerMelee playerMelee;
	public PlayerMovement playerMovement;
	public PlayerSpell playerSpell;

	//enemy scripts for taking damage and spell effects on enemies
	public EnemyHealth enemyHealth;

	public GameObject explosion;
	public GameObject eSpell;

	public bool tookTeleDamage;

	public bool fireBallCountdown;
	public int fireBallTimer;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("PlayerObject");
		melee = GameObject.Find("Melee");
		playerContainer = GameObject.Find("Player");
		playerExp = player.GetComponent<PlayerExp>();
		playerHealth = player.GetComponent<PlayerHealth>();
		playerMelee = melee.GetComponent<PlayerMelee>();
		playerMovement = playerContainer.GetComponent<PlayerMovement>();
		healOffset = -2;
		playerSpell = player.GetComponent<PlayerSpell>();
		tookTeleDamage = false;
		Speed = 15;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(active)
		{
			dTimer++;

			//different positions for different types of spells
			if(fire)
			{
				spellP = this.transform.position;
				spellP += Speed * this.transform.forward * Time.deltaTime;
			}
			if(ice)
			{
				spellP = player.transform.position;
				spellP += 1 * player.transform.forward;
				this.transform.forward = player.transform.forward;
			}
			if(lightning)
			{
				spellP = player.transform.position;
				this.GetComponent<ParticleSystem>().startSize += .5f;
			}
			if(heal)
			{
				healOffset += .03f;
				spellP = player.transform.position;
				spellP.y += healOffset;

				//heal effects
				playerHealth.currentHealth += playerSpell.healAmount;
			}
			if(levelUp)
			{
				spellP = player.transform.position;
				spellP.y-=2;
			}
			if(tele)
			{
				spellP = player.transform.position;
				spellP.y-=2;
			}
			if(tele2)
			{
				//teleport to tracker
				spellP = playerMovement.spellEffect.transform.position;
			}
			this.transform.position = spellP;
		}

		//end spell
		if(dTimer > duration && !tracker)
		{
			active = false;
			Destroy(gameObject);
		}

		if(fireBallCountdown)
		{
			fireBallTimer++;
		}
		if(fireBallTimer > 20)
		{
			Destroy(gameObject);
		}
	}

	//delete the enemy if they are hit by melee box
	void OnTriggerEnter(Collider Collection)
	{
		Debug.Log("HitTrigger");
		if (Collection.gameObject.tag == "Enemy")
		{
			Debug.Log("HitEnemy");
			enemyHealth = Collection.GetComponent<EnemyHealth>();

			if(fire)
			{
				//fireball effects here
				Destroy(gameObject);
				enemyHealth.TakeDamage(playerSpell.fireDamage);
				//explosion
				explosion = (GameObject)Instantiate(eSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
			}
			if(ice)
			{
				//ice effects here
				enemyHealth.ice = true;
			}
			if(lightning)
			{
				//lightning effects here
				enemyHealth.TakeDamage(playerSpell.lightningDamage);
				Vector3 sparkLoc = enemyHealth.transform.position;
				sparkLoc.y += 2;
				explosion = (GameObject)Instantiate(eSpell, sparkLoc, this.gameObject.transform.rotation);
			}
			if(tele2 && !tookTeleDamage)
			{
				enemyHealth.TakeDamage(playerSpell.teleDamage);
				tookTeleDamage = true;
				Vector3 sparkLoc = enemyHealth.transform.position;
				sparkLoc.y += 2;
				explosion = (GameObject)Instantiate(eSpell, sparkLoc, this.gameObject.transform.rotation);
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("HitCollider");
		if(fire)
		{
			//fireball effects here
			//Destroy(gameObject);
			//explosion
			if(!fireBallCountdown)
			{
				explosion = (GameObject)Instantiate(eSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
			}
			fireBallCountdown = true;
		}
	}

	void OnTriggerExit(Collider Collection)
	{

		if (Collection.gameObject.tag == "Enemy")
		{
			enemyHealth = Collection.GetComponent<EnemyHealth>();
			if(ice)
			{
				enemyHealth.ice = false;
			}
		}
	}

}
