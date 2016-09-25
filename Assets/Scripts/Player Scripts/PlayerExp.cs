using UnityEngine;
using System.Collections;

public class PlayerExp : MonoBehaviour {

	public int exp;
	public int levelUps;
	public int parts;
	public int level;
	public int stats;
	public int spellPoints;
	public int upgradeLevel;

	public GameObject furySpell;
	public GameObject levelUp;
	public bool levelUpActive;
	public int levelUpTimer;
	public Vector3 levelUpOffset;
	public float offSet;
	
	//spell prefabs
	public GameObject newSpell;

	//spell effect script
	public SpellEffect spellEffect;

	//uppgrade part objects...need these to turn renderer off and on while upgrading mage
	public GameObject armLeft;
	public GameObject armRight;

	public GameObject legLeft;
	public GameObject legRight;

	public GameObject chest;

	public GameObject head;

	public GameObject exitZone;

	// Use this for initialization
	void Start () {
		exp = 0;
		levelUps = 0;
		parts = 0;
		level = 1;
		stats = 0;
		spellPoints = 0;
		levelUp = GameObject.Find ("LevelUpText");
		levelUpActive = false;
		levelUpTimer = 0;
		offSet = 0;
		upgradeLevel = 0;

		//parts
		armLeft = GameObject.Find("Arm Piece Left");
		armRight = GameObject.Find("Arm Piece Right");


		legLeft = GameObject.Find("Leg Piece Left");
		legRight = GameObject.Find("Leg Piece Right");

		chest = GameObject.Find("Chest Piece Model");

		head = GameObject.Find("Head Piece Model");


		exitZone = GameObject.Find ("NextLevelBarrier");

		if(Application.loadedLevel == 1)
		{
			stats = 8;
			spellPoints = 8;
			parts = 30;
		}
		if(Application.loadedLevel == 2)
		{
			stats = 16;
			spellPoints = 15;
			parts = 60;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//arms first
		if(upgradeLevel > 0)
		{
			armLeft.GetComponent<Renderer>().enabled = true;
			armRight.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			armLeft.GetComponent<Renderer>().enabled = false;
			armRight.GetComponent<Renderer>().enabled = false;
		}

		//legs next
		if(upgradeLevel > 1)
		{
			legLeft.GetComponent<Renderer>().enabled = true;
			legRight.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			legLeft.GetComponent<Renderer>().enabled = false;
			legRight.GetComponent<Renderer>().enabled = false;
		}
		//chest next
		if(upgradeLevel > 2)
		{
			chest.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			chest.GetComponent<Renderer>().enabled = false;
		}
		//head next
		if(upgradeLevel > 3)
		{
			head.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			head.GetComponent<Renderer>().enabled = false;
		}

		if(upgradeLevel >= 2 && Application.loadedLevel == 0)
		{
			Destroy(exitZone.GetComponent<Collider>());
		}
		if(upgradeLevel >= 4 && Application.loadedLevel == 1)
		{
			Destroy(exitZone.GetComponent<Collider>());
		}

		if(levelUpActive)
		{
			levelUpTimer++;
			levelUp.GetComponent<Renderer>().enabled = true;

			//make the text scroll up
			levelUpOffset = this.transform.position;
			offSet += .025f;
			levelUpOffset.y += offSet;
			levelUp.transform.position = levelUpOffset;
		}
		if(levelUpTimer > 120)
		{
			levelUpTimer = 0;
			levelUpActive = false;
			levelUp.GetComponent<Renderer>().enabled = false;
			offSet = 0;
		}
		if(exp >= 100)
		{
			//mechanics of leveling up
			levelUpActive = true;
			exp = 0;
			levelUps++;
			level++;
			stats += 1;
			spellPoints += 1;

			//level up animation
			newSpell = (GameObject)Instantiate(furySpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
			spellEffect = newSpell.GetComponent<SpellEffect>();
			spellEffect.levelUp = true;
			spellEffect.duration = 120;
			spellEffect.active = true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Exit")
		{
			Application.LoadLevel("SciFi2");
		}
		if (col.gameObject.tag == "Exit2")
		{
			Application.LoadLevel("Demo6");
		}
	}
}
