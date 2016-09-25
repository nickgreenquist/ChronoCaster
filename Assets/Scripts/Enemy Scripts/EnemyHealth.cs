using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;
	public int expAmount;

	//player vars for giving exp
	public GameObject player;
	public PlayerExp playerExp;
	public PlayerSpell playerSpell;

	//ice effect
	public bool ice;
	public int iceCounter = 0;

	//part drop gameobject
	public GameObject partPrefab;

	public int soundCounter = 0;

    // Use this for initialization
    void Awake()
    {
       // score = GameObject.Find("GUI").GetComponent<ScoreCounterGUI>();
        currentHealth = maxHealth;
		expAmount = 25;
		player = GameObject.Find("PlayerObject");
		playerExp = player.GetComponent<PlayerExp>();
		playerSpell = player.GetComponent<PlayerSpell>();
    }

    // Update is called once per frame
    void Update()
    {
		if (currentHealth <= 0)
		{
			playerExp.exp += expAmount;
			Destroy(gameObject);
			
			//drop upgrade
			GameObject part = (GameObject)Instantiate(partPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
		}

		//ice effects
		Component halo = this.GetComponent("Halo"); 
		if(ice)
		{
			iceCounter++;
			halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
			TakeDamage(playerSpell.iceDamage);
		}
		if(iceCounter > 180 || !ice)
		{
			iceCounter = 0;
			ice = false;
			halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		}
    }

    public void TakeDamage(float damage)
    {
		currentHealth -= damage;
    }
}
