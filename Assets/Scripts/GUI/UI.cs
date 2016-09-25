using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	
	public GameObject player;
	public GameObject melee;
	public GameObject playerC;
	public PlayerSpell playerSpell;
	public PlayerHealth playerHealth;
	public PlayerExp playerExp;
	public PlayerMelee playerMelee;
	public PlayerMovement playerMovement;
	string spell;
	public Vector3 tempCameraPos;
	public Transform tempTransform;
	public Vector3 tempPos;
	public Quaternion tempRotation;
	public GameObject camera;

	
	//ui texture
	public Texture texture;
	public Texture textureLevelUp;
	public Texture red;
	public Texture blue;
	public Texture green;
	public Texture yellow;
	public Texture black;
	
	public int redX;
	public int redY;
	public int redWidth;
	public int redHeight;
	
	public int blueX;
	public int blueY;
	public int blueWidth;
	public int blueHeight;
	
	public int greenX;
	public int greenY;
	public int greenWidth;
	public int greenHeight;
	
	public int uiX;
	public int uiY;
	public int uiWidth;
	public int uHeight;
	public float ratio = .3125f;

	//menu code
	public bool isPause = false;
	public int width = 300;
	public int height = 100;

	public Texture pauseMenu;

	public int statY;

	public int levelX;
	public int levelY;
	public int levelW;
	public int levelH;

	public int strengthY;
	public int strengthW;
	public int strengthH;

	public int speedY;

	public int magicY;

	public int healthY;

	//current stat numbers
	public int pStrengthX;

	//spell textures
	public Texture fireballLocked;
	public Texture fireball;
	public Texture fireball2;
	public Texture fireball3;
	public Texture iceLocked;
	public Texture ice;
	public Texture ice2;
	public Texture ice3;
	public Texture lightLocked;
	public Texture light;
	public Texture light2;
	public Texture light3;
	public Texture healLocked;
	public Texture heal;
	public Texture heal2;
	public Texture heal3;
	public Texture teleLocked;
	public Texture tele;
	public Texture tele2;
	public Texture tele3;

	//positions for spells and ui boxes/buttons
	public int spellPointsX;
	public int spellPointsY;
	public int spellPointsW;
	public int spellPointsH;

	public int fireballX;
	public int fireballY;
	public int fireballW;
	public int fireballH;

	public int iceX;
	public int iceY;
	public int iceW;
	public int iceH;

	public int lightX;
	public int lightY;
	public int lightW;
	public int lightH;

	public int healX;
	public int healY;
	public int healW;
	public int healH;

	public int teleX;
	public int teleY;
	public int teleW;
	public int teleH;

	//buttons
	public int buttonSize;
	public int fireButtonX;
	public int fireButtonY;

	public int iceButtonX;
	public int iceButtonY;

	public int lightButtonX;
	public int lightButtonY;

	public int healButtonX;
	public int healButtonY;

	public int teleButtonX;
	public int teleButtonY;

	public int partsX;
	public int partsY;

	public int partsButtonX;
	public int partsButtonY;

	public int introTimer;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find ("PlayerObject");
		melee = GameObject.Find("Melee");
		playerC = GameObject.Find("Player");
		playerSpell = player.GetComponent<PlayerSpell>();
		playerHealth = player.GetComponent<PlayerHealth>();
		playerExp = player.GetComponent<PlayerExp>();
		playerMelee = melee.GetComponent<PlayerMelee>();
		playerMovement = playerC.GetComponent<PlayerMovement>();
		spell = "";
		camera = GameObject.Find("Main Camera");

		//normal ui positions
		//gui positioning
		redX = Screen.width / 4;
		redY = Screen.height - (Screen.height / 11);
		redHeight = Screen.height / 50;
		redWidth = (int)(Screen.width / 7.75);
		
		blueX = (int)(Screen.width / 1.62);
		blueY = Screen.height - (Screen.height / 11);
		blueHeight = Screen.height / 50;
		blueWidth = (int)(Screen.width / 7.75);
		
		greenX = (int)(Screen.width / 2.6);
		greenY = Screen.height - (Screen.height / 11);
		greenHeight = Screen.height / 50;
		greenWidth = (int)(Screen.width / 4.3);
		
		uiX = Screen.width / 4;
		uiY = Screen.height - (int)(Screen.height / 2.5);
		uiWidth = Screen.width / 2;
		
		//why won't this work!?!?!?!?!?!
		ratio = 0.3125f;
		Cursor.visible = false;

		//paused game positions
		levelX = (int)(Screen.width / 4.5);
		levelY = Screen.height / 10;
		levelW = Screen.width / 20;
		levelH = Screen.height / 20;

		statY = (int)(Screen.height / 4.2);

		strengthW = levelH;
		strengthH = levelH;
		strengthY = (int)(Screen.height / 2.95);

		speedY = (int)(Screen.height / 2.1);

		healthY = (int)(Screen.height / 1.63);

		magicY = (int)(Screen.height / 1.33);

		//current stats
		pStrengthX = (int)(Screen.width / 7.5);

		//spells
		spellPointsX = (int)(Screen.width / 1.1);
		spellPointsY = levelY;
		spellPointsW = levelW;
		spellPointsH = levelH;

		fireballX = (int)(Screen.width / 1.35);
		fireballY = (int)(Screen.height / 5);
		fireballW = Screen.width / 12;
		fireballH = fireballW;

		iceX = (int)(Screen.width / 1.15);
		iceY = fireballY;
		iceW = fireballW;
		iceH = fireballH;

		lightX = fireballX;
		lightY = (int)(Screen.height / 2.1);;
		lightW = fireballW;
		lightH = fireballH;

		healX = iceX;
		healY = lightY;
		healW = fireballW;
		healH = fireballH;

		teleX = (int)(Screen.width / 1.25);
		teleY = (int)(Screen.height / 1.35);
		teleW = fireballW;
		teleH = fireballH;

		//+ buttons for spells
		fireButtonX = (int)(Screen.width / 1.3);
		fireButtonY = (int)(Screen.height / 2.6);

		iceButtonX = (int)(Screen.width / 1.11);
		iceButtonY = fireButtonY;

		lightButtonX = fireButtonX;
		lightButtonY = (int)(Screen.height / 1.5);

		healButtonX = iceButtonX;
		healButtonY = lightButtonY;

		teleButtonX = (int)(Screen.width / 1.2);
		teleButtonY = (int)(Screen.height / 1.08);

		buttonSize = levelH;

		partsX = (int)(Screen.width / 2.1);
		partsY = spellPointsY;

		partsButtonX = (int)(Screen.width / 1.75);
		partsButtonY = spellPointsY;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(introTimer < 800)
		{
			introTimer++;
		}

		uHeight = (int)(uiWidth * ratio);
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			print("keypresssed");
			if(!isPause)
			{
				PauseGame();
				Cursor.visible = true;
			}
			else if(isPause)
			{
				UnPause();
				Cursor.visible = false;
			}
		}

		if(isPause)
		{
			Cursor.visible = true;
		}
		else
		{
			Cursor.visible = false;
		}

	}
	
	void OnGUI()
	{
		/*
		//win condition for prototype
		if(playerExp.parts > 50)
		{
			for(int i = 0; i < Screen.width; i += 75)
			{
				for(int j = 0; j < Screen.height; j += 75)
				{
					GUI.Box(new Rect(i,j,65,65), "You Win!");
				}
			}
		}
		*/

		//pause menu ui
		if(isPause)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseMenu);
			GUI.Box(new Rect(levelX, levelY, levelW, levelH), "" + playerExp.level);
			GUI.Box(new Rect(levelX, statY, levelW, levelH), "" + playerExp.stats);
			//level up buttons
			if(GUI.Button(new Rect(levelX, strengthY, strengthW, strengthH), "+"))
			{
				if(playerExp.stats >= 1 && playerMelee.strength < 10)
				{
					print("strength up");
					playerExp.stats--;
					playerMelee.strength++;
				}
			}
			if(GUI.Button(new Rect(levelX, speedY, strengthW, strengthH), "+"))
			{
				if(playerExp.stats >= 1 && playerMovement.speedStat < 10)
				{
					print("speed up");
					playerExp.stats--;
					playerMovement.speedStat++;
					playerMovement.speedStatReal += .5f;		//don't upgrade too much...the other stat is for displaying in the UI
				}
			}
			if(GUI.Button(new Rect(levelX, healthY, strengthW, strengthH), "+"))
			{
				if(playerExp.stats >= 1 && playerHealth.health < 10)
				{
					print("health up");
					playerExp.stats--;
					playerHealth.health++;
				}
			}
			if(GUI.Button(new Rect(levelX, magicY, strengthW, strengthH), "+"))
			{
				if(playerExp.stats >= 1 && playerSpell.manaStat < 10)
				{
					print("mana up");
					playerExp.stats--;
					playerSpell.manaStat++;
					playerSpell.manaRegenRate++;
				}
			}
			//current stat numbers
			GUI.Box(new Rect(pStrengthX, strengthY, strengthW, strengthH), "" + playerMelee.strength);
			GUI.Box(new Rect(pStrengthX, speedY, strengthW, strengthH), "" + playerMovement.speedStat);
			GUI.Box(new Rect(pStrengthX, healthY, strengthW, strengthH), "" + playerHealth.health);
			GUI.Box(new Rect(pStrengthX, magicY, strengthW, strengthH), "" + playerSpell.manaStat);

			//spells menu
			GUI.Box(new Rect(spellPointsX, spellPointsY, spellPointsW, spellPointsH), "" + playerExp.spellPoints);
			if(playerSpell.spells[0] == 0)
			{
				GUI.DrawTexture(new Rect(fireballX, fireballY, fireballW, fireballH), fireballLocked);
			}
			else if(playerSpell.spells[0] == 1)
			{
				GUI.DrawTexture(new Rect(fireballX, fireballY, fireballW, fireballH), fireball);
			}
			else if(playerSpell.spells[0] == 2)
			{
				GUI.DrawTexture(new Rect(fireballX, fireballY, fireballW, fireballH), fireball2);
			}
			else if(playerSpell.spells[0] == 3)
			{
				GUI.DrawTexture(new Rect(fireballX, fireballY, fireballW, fireballH), fireball3);
			}
			if(playerSpell.spells[1] == 0)
			{
				GUI.DrawTexture(new Rect(iceX, iceY, iceW, iceH), iceLocked);
			}
			else if(playerSpell.spells[1] == 1)
			{
				GUI.DrawTexture(new Rect(iceX, iceY, iceW, iceH), ice);
			}
			else if(playerSpell.spells[1] == 2)
			{
				GUI.DrawTexture(new Rect(iceX, iceY, iceW, iceH), ice2);
			}
			else if(playerSpell.spells[1] == 3)
			{
				GUI.DrawTexture(new Rect(iceX, iceY, iceW, iceH), ice3);
			}
			if(playerSpell.spells[2] == 0)
			{
				GUI.DrawTexture(new Rect(lightX, lightY, lightW, lightH), lightLocked);
			}
			else if(playerSpell.spells[2] == 1)
			{
				GUI.DrawTexture(new Rect(lightX, lightY, lightW, lightH), light);
			}
			else if(playerSpell.spells[2] == 2)
			{
				GUI.DrawTexture(new Rect(lightX, lightY, lightW, lightH), light2);
			}
			else if(playerSpell.spells[2] == 3)
			{
				GUI.DrawTexture(new Rect(lightX, lightY, lightW, lightH), light3);
			}
			if(playerSpell.spells[3] == 0)
			{
				GUI.DrawTexture(new Rect(healX, healY, healW, healH), healLocked);
			}
			else if(playerSpell.spells[3] == 1)
			{
				GUI.DrawTexture(new Rect(healX, healY, healW, healH), heal);
			}
			else if(playerSpell.spells[3] == 2)
			{
				GUI.DrawTexture(new Rect(healX, healY, healW, healH), heal2);
			}
			else if(playerSpell.spells[3] == 3)
			{
				GUI.DrawTexture(new Rect(healX, healY, healW, healH), heal3);
			}
			if(playerSpell.spells[4] == 0)
			{
				GUI.DrawTexture(new Rect(teleX, teleY, teleW, teleH), teleLocked);
			}
			else if(playerSpell.spells[4] == 1)
			{
				GUI.DrawTexture(new Rect(teleX, teleY, teleW, teleH), tele);
			}
			else if(playerSpell.spells[4] == 2)
			{
				GUI.DrawTexture(new Rect(teleX, teleY, teleW, teleH), tele2);
			}
			else if(playerSpell.spells[4] == 3)
			{
				GUI.DrawTexture(new Rect(teleX, teleY, teleW, teleH), tele3);
			}
			//spell level up buttons
			if(GUI.Button(new Rect(fireButtonX, fireButtonY, buttonSize, buttonSize), "+"))
			{
				if(playerExp.spellPoints >= 1 && playerSpell.spells[0] < 3) //max level of spell is 3
				{
					playerExp.spellPoints--;
					playerSpell.spells[0]++; //upgrade fire spell
				}
			}
			if(GUI.Button(new Rect(iceButtonX, iceButtonY, buttonSize, buttonSize), "+"))
			{
				if(playerExp.spellPoints >= 1 && playerSpell.spells[1] < 3)
				{
					playerExp.spellPoints--;
					playerSpell.spells[1]++; //upgrade ice spell
				}
			}
			if(GUI.Button(new Rect(lightButtonX, lightButtonY, buttonSize, buttonSize), "+"))
			{
				if(playerExp.spellPoints >= 1 && playerSpell.spells[2] < 3)
				{
					playerExp.spellPoints--;
					playerSpell.spells[2]++; //upgrade lightning spell
				}
			}
			if(GUI.Button(new Rect(healButtonX, healButtonY, buttonSize, buttonSize), "+"))
			{
				if(playerExp.spellPoints >= 1 && playerSpell.spells[3] < 3)
				{
					playerExp.spellPoints--;
					playerSpell.spells[3]++; //upgrade heal spell
				}
			}

			if(GUI.Button(new Rect(teleButtonX, teleButtonY, buttonSize, buttonSize), "+"))
			{
				if(playerExp.spellPoints >= 1 && playerSpell.spells[4] < 3)
				{
					playerExp.spellPoints--;
					playerSpell.spells[4]++; //upgrade tele spell
				}
			}

			//upgrade parts positions
			if(GUI.Button(new Rect(partsButtonX, partsButtonY, buttonSize, buttonSize), "+"))
			{
				if(playerExp.parts >= 15 && playerExp.upgradeLevel <= 3)
				{
					playerExp.parts -= 15;
					playerExp.upgradeLevel++;
					if(playerExp.upgradeLevel == 1)
					{
						playerMelee.strength++;
					}
					if(playerExp.upgradeLevel == 2)
					{
						playerMovement.speedStat++;
						playerMovement.speedStatReal += .5f;
					}
					if(playerExp.upgradeLevel == 3)
					{
						playerHealth.health++;
					}
					if(playerExp.upgradeLevel == 4)
					{
						playerSpell.manaStat++;
					}
				}
			}

			GUI.Box(new Rect(partsX, partsY, spellPointsW, spellPointsH), "" + playerExp.parts + " / " + 15);

		}
		//normal game ui
		else
		{
			if(introTimer < 720 && Application.loadedLevel == 0)
			{
			GUI.Box(new Rect(Screen.width / 2 - 125, 25, 250, 30), "Welcome to ChronoCaster!");
			GUI.Box(new Rect(Screen.width / 2 - 125, 50, 250, 30), "Kill robots and collect parts");
			GUI.Box(new Rect(Screen.width / 2 - 125, 75, 250, 30), "Hit ESC to open up character menu");
			GUI.Box(new Rect(Screen.width / 2 - 125, 100, 250, 30), "Hold LEFT CLICK down to move");
			GUI.Box(new Rect(Screen.width / 2 - 125, 125, 250, 30), "Upgrade your mage with parts to progress");
			GUI.Box(new Rect(Screen.width / 2 - 125, 150, 250, 30), "Open up the menu to upgrade your mage");
			}
		
		
		//UI
		//draw health
		GUI.DrawTexture(new Rect(redX, redY, (int)(redWidth * (playerHealth.currentHealth / playerHealth.maxHealth)), redHeight), red);
		
		//draw mana
		float manaRatio = playerSpell.manaF / playerSpell.maxManaF;
		GUI.DrawTexture(new Rect(blueX, blueY, (int)(blueWidth * manaRatio), blueHeight), blue);
		
		//draw experience
		GUI.DrawTexture(new Rect(greenX, greenY, (int)(greenWidth * playerExp.exp / 100), greenHeight), green);

		//new UI
		if(playerExp.stats <= 0 && playerExp.spellPoints <= 0)
		{
			GUI.DrawTexture(new Rect(uiX, uiY, uiWidth, uHeight), texture);
		}
		else
		{
			GUI.DrawTexture(new Rect(uiX, uiY, uiWidth, uHeight), textureLevelUp);
		}

			//draw black boxes over inactive spells
			GUIStyle style = new GUIStyle();
			
			if(playerSpell.spells[0] == 0)
			{
				GUI.DrawTexture(new Rect((int)(Screen.width / 2.12), Screen.height - (int)(Screen.height / 6.5), fireballW  /3, fireballH / 3), black); //fire
			}
			if(playerSpell.spells[1] == 0)
			{
				GUI.DrawTexture(new Rect((int)(Screen.width / 2), Screen.height - (int)(Screen.height / 6.5), fireballW  /3, fireballH / 3), black); //ice
			}
			if(playerSpell.spells[2] == 0)
			{
				GUI.DrawTexture(new Rect((int)(Screen.width / 1.89), Screen.height - (int)(Screen.height / 6.5), fireballW  /3, fireballH / 3), black); //light
			}
			if(playerSpell.spells[3] == 0)
			{
				GUI.DrawTexture(new Rect((int)(Screen.width / 1.79), Screen.height - (int)(Screen.height / 6.5), fireballW  /3, fireballH / 3), black); //heal
			}
			if(playerSpell.spells[4] == 0)
			{
				GUI.DrawTexture(new Rect((int)(Screen.width / 1.7), Screen.height - (int)(Screen.height / 6.5), fireballW  /3, fireballH / 3), black); //tele
			}
		}

	}

	//pause game helper functions
	void PauseGame()
	{
		isPause = true;
		Time.timeScale = 0;
		tempCameraPos = camera.transform.position;
		tempRotation = camera.transform.rotation;
		tempPos = player.transform.position;
		tempPos.y +=1;
		camera.transform.rotation = player.transform.rotation;
		camera.transform.position = tempPos;
		camera.transform.Translate(Vector3.forward * 10);
		camera.transform.LookAt(player.transform);
	}
	
	void UnPause()
	{
		isPause = false;
		Time.timeScale = 1;
		camera.transform.position = tempCameraPos;
		camera.transform.rotation = tempRotation;
	}
}
