using UnityEngine;
using System.Collections;

public class PlayerSpell : MonoBehaviour {

	//object to hold spell particle
	public GameObject fireSpell;
	public GameObject fireSpell1;
	public GameObject fireSpell2;
	public GameObject iceSpell;
	public GameObject iceSpell1;
	public GameObject iceSpell2;
	public GameObject lightningSpell;
	public GameObject lightningSpell1;
	public GameObject lightningSpell2;
	public GameObject healSpell;
	public GameObject healSpell1;
	public GameObject healSpell2;
	public GameObject teleportSpell;
	public GameObject teleportSpell1;
	public GameObject teleportSpell2;

	public int fireDamage;
	public int iceDamage;
	public int lightningDamage;
	public int healAmount;
	public int teleDamage;

	//spell prefabs
	public GameObject newSpell;
	public GameObject newSpell2;

	//active spell
	public int activeSpell = 0;	//0 = fireball, 1 = ice, 2 = lightning, 3 = heal, 4 = fury, 5 = tele

	//spell types
	public int[] spells; //0 == locked, 1 == level1...2 ==  level3 (fully upgraded)

	//spell costs
	public int[] spellCosts;

	//spell durations
	public int[] spellDurs;

	//spell effect script
	public SpellEffect spellEffect;
	public SpellEffect spellEffect2;

	//mana
	public int manaStat;
	public int mana;
	public int maxMana;
	public int manaRegenRate;

	//for ui use
	public float manaF;
	public float maxManaF;

	//teleport temp position
	public bool tele;
	public Vector3 teleP;
	public int teleTimer = 0;

	//player container
	public GameObject playerC;

	//scroll wheel for selecting spell variables
	public float scrollWheelNum;

	//cooldown is different for different spells
	public int cooldownTimer = 0;
	public int[] cooldowns;

	//for tele use
	public PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		manaStat = 5;
		//set active spells to false
		spells = new int[5];
		spells[0] = 1; //give the player fire ball at the start

		maxMana = manaStat * 200;		//divide by ten to show
		mana = maxMana;
		manaRegenRate = 1;

		//for ui use
		manaF = mana;
		maxManaF = maxMana;

		playerC = GameObject.Find("Player");

		//set spell costs all the same
		spellCosts = new int[5];
		for(int i = 0; i < spellCosts.Length; i++)
		{
			spellCosts[i] = 100;
		}
		//some spells should be more
		spellCosts[1] = 200;
		spellCosts[2] = 300;
		spellCosts[3] = 300;
		spellCosts[4] = 200;

		//set spell durations
		spellDurs = new int[5];
		spellDurs[0] = 180;
		spellDurs[1] = 180;
		spellDurs[2] = 30;
		spellDurs[3] = 120;
		spellDurs[4] = 45;

		//set spell cooldowns
		cooldowns = new int[5];	//dont set any to zero!!!!
		cooldowns[0] = 5;
		cooldowns[1] = 30;
		cooldowns[2] = 30;
		cooldowns[3] = 30;
		cooldowns[4] = 45;

		//use for tele
		playerMovement = playerC.GetComponent<PlayerMovement>();

		//set damages
		fireDamage = 50;
		iceDamage = 1;
		lightningDamage = 25;			//for some reason this is applied twice so set to half of what you want
		healAmount = 1;
		teleDamage = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//update spell effects based on spell level
		if(spells[0] == 2)
		{
			fireDamage = 75;
		}
		if(spells[0] == 3)
		{
			fireDamage = 100;
		}
		if(spells[1] == 2)
		{
			iceDamage = 2;;
		}
		if(spells[1] == 3)
		{
			iceDamage = 2;;
		}
		if(spells[2] == 2)
		{
			lightningDamage = 35;
		}
		if(spells[2] == 3)
		{
			lightningDamage = 50;
		}
		if(spells[3] == 2)
		{
			healAmount = 2;
		}
		if(spells[3] == 3)
		{
			healAmount = 3;
		}
		if(spells[4] == 2)
		{
			teleDamage = 50;
		}
		if(spells[4] == 3)
		{
			teleDamage = 100;
		}

		maxMana = manaStat * 200;
		maxManaF = maxMana;
		//for ui use, dont delete!!!!!
		manaF = mana;

		cooldownTimer++;

		//mana regen
		if(mana < maxMana)
		{
			mana += manaRegenRate;
		}
	
			if(mana > 0)
			{
				//change 99 and 100 to custom mana costs
				if(mana > spellCosts[0] - 1 && cooldownTimer > cooldowns[0] && Input.GetKeyDown(KeyCode.Alpha1) && spells[0] > 0)
				{
					cooldownTimer = 0;
				
				if(spells[0] == 1)
				{
					newSpell = (GameObject)Instantiate(fireSpell, this.gameObject.transform.position + this.transform.forward  * 2, this.gameObject.transform.rotation);
				}
				else if(spells[0] == 2)
				{
					newSpell = (GameObject)Instantiate(fireSpell1, this.gameObject.transform.position +this.transform.forward * 2, this.gameObject.transform.rotation);
				}
				else if(spells[0] == 3)
				{
					newSpell = (GameObject)Instantiate(fireSpell2, this.gameObject.transform.position + this.transform.forward * 2, this.gameObject.transform.rotation);
				}
					spellEffect = newSpell.GetComponent<SpellEffect>();
					spellEffect.fire = true;
					spellEffect.duration = spellDurs[0];
					spellEffect.active = true;
					mana -= spellCosts[0];
				}
			else if(mana > spellCosts[1] - 1 && cooldownTimer > cooldowns[1] && Input.GetKeyDown(KeyCode.Alpha2) && spells[1] > 0)
				{
					cooldownTimer = 0;
				if(spells[1] == 1)
				{
					newSpell = (GameObject)Instantiate(iceSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[1] == 2)
				{
					newSpell = (GameObject)Instantiate(iceSpell1, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[1] == 3)
				{
					newSpell = (GameObject)Instantiate(iceSpell2, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
					spellEffect = newSpell.GetComponent<SpellEffect>();
					spellEffect.ice = true;
					spellEffect.duration = spellDurs[1];
					spellEffect.active = true;
					mana -= spellCosts[1];
				}
			else if(mana > spellCosts[2] - 1 && cooldownTimer > cooldowns[2] && Input.GetKeyDown(KeyCode.Alpha3) && spells[2] > 0)
				{
					cooldownTimer = 0;
				if(spells[2] == 1)
				{
					newSpell = (GameObject)Instantiate(lightningSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[2] == 2)
				{
					newSpell = (GameObject)Instantiate(lightningSpell1, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[2] == 3)
				{
					newSpell = (GameObject)Instantiate(lightningSpell2, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
					spellEffect = newSpell.GetComponent<SpellEffect>();
					spellEffect.lightning = true;
					spellEffect.duration = spellDurs[2];
					spellEffect.active = true;
					mana -= spellCosts[2];
				}
			else if(mana > spellCosts[3] - 1 && cooldownTimer > cooldowns[3] && Input.GetKeyDown(KeyCode.Alpha4) && spells[3] > 0)
				{
					cooldownTimer = 0;
				if(spells[3] == 1)
				{
					newSpell = (GameObject)Instantiate(healSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[3] == 2)
				{
					newSpell = (GameObject)Instantiate(healSpell1, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[3] == 3)
				{
					newSpell = (GameObject)Instantiate(healSpell2, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
					spellEffect = newSpell.GetComponent<SpellEffect>();
					spellEffect.heal = true;
					spellEffect.duration = spellDurs[3];
					spellEffect.active = true;
					mana -= spellCosts[3];
				}
			else if(mana > spellCosts[4] - 1 && cooldownTimer > cooldowns[4] && Input.GetKeyDown(KeyCode.Alpha5) && spells[4] > 0)
				{
					cooldownTimer = 0;
				if(spells[4] == 1)
				{
					newSpell = (GameObject)Instantiate(teleportSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
					newSpell2 = (GameObject)Instantiate(teleportSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[4] == 2)
				{
					newSpell = (GameObject)Instantiate(teleportSpell1, this.gameObject.transform.position, this.gameObject.transform.rotation);
					newSpell2 = (GameObject)Instantiate(teleportSpell1, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
				else if(spells[4] == 3)
				{
					newSpell = (GameObject)Instantiate(teleportSpell2, this.gameObject.transform.position, this.gameObject.transform.rotation);
					newSpell2 = (GameObject)Instantiate(teleportSpell2, this.gameObject.transform.position, this.gameObject.transform.rotation);
				}
					spellEffect = newSpell.GetComponent<SpellEffect>();
					spellEffect.tele = true;
					spellEffect.duration = (int)(spellDurs[4] * 1.25);
					spellEffect.active = true;
					mana -= spellCosts[4];
					tele = true;
					
					//second spell effect for teleport
					spellEffect2 = newSpell2.GetComponent<SpellEffect>();
					spellEffect2.tele2 = true;
					spellEffect2.active = true;
					spellEffect2.duration = spellDurs[4] - 2;
				}
		}

		if(tele)
		{
			teleTimer++;
			if(teleTimer > spellDurs[4])
			{
				//teleport to mouse location
				playerC.transform.position = playerMovement.spellEffect.transform.position;

				//reset
				tele = false;
				teleTimer = 0;
			}
		}

	}


}
