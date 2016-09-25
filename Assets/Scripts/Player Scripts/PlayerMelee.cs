using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour {

    //vars
    public BoxCollider bc;
    public int meleeTimer = 0;			//how long melee is active
    public int meleeCooldown = 0;		//how long until you can melee again
    public int meleeCooldownTimer;
    Vector3 cp;
	public float strength;
	public float meleeDamage;

	public EnemyHealth enemyHealth;

    Transform meleeT;
    Vector3 meleeP;

    public GameObject player;
    Vector3 playerP;

	//hit effect
	public GameObject hitEffect;

	public GameObject playerC;
	public PlayerMovement playerMovement;

	public Animator anim;

	public bool tookMeleeDamage;

    // Use this for initialization
    void Start()
    {
        meleeCooldownTimer = 30;
        meleeT = gameObject.transform;

        player = GameObject.Find("PlayerObject");
        playerP = player.transform.position;

		//renderer.enabled = false;

		strength = 5;
		meleeDamage = strength * 10;

		playerC = GameObject.Find ("Player");
		playerMovement = playerC.GetComponent<PlayerMovement>();
		anim = playerMovement.anim;

		tookMeleeDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
		meleeDamage = strength * 10;
        if (gameObject.GetComponent<Collider>() != null) //melee active
        {
            meleeTimer++;				//increase melee active timer
			anim.speed = 1;
        }
        else 							//melee inactive, update cooldown
        {
            meleeCooldown++;
        }
        //set how long you want melee to be up
        if (meleeTimer >= 45)
        {
			playerMovement.anim.SetBool("Melee", false);
			//renderer.enabled = false;
            Destroy(GetComponent<Collider>());
            meleeTimer = 0;
            meleeCooldown = 0;
			tookMeleeDamage = false;
        }

        //use your melee ability
		if (Input.GetMouseButtonDown(1) && GetComponent<Collider>() == null && meleeCooldown > meleeCooldownTimer) //melee button down and no current melee active and melee cooldown over
        {
			playerMovement.anim.SetBool("Melee", true);
            //melee is done by adding a box collider
            if (gameObject.GetComponent<Collider>() == null)
            {
				//renderer.enabled = true;
                bc = gameObject.AddComponent<BoxCollider>();
                BoxCollider current = gameObject.GetComponent<Collider>() as BoxCollider;
                GetComponent<Collider>().isTrigger = true;
                meleeCooldown = 0;
            }
        }
    }

    //delete the enemy if they are hit by melee box
    void OnTriggerEnter(Collider Collection)
	{
		enemyHealth = Collection.GetComponent<EnemyHealth>();
        if (Collection.gameObject.tag == "Enemy" && !tookMeleeDamage)
        {
			enemyHealth.TakeDamage(meleeDamage);

			//hit effect
			Vector3 hitPos = enemyHealth.transform.position;
			hitPos.y += 2;
			GameObject newHitEffect = (GameObject)Instantiate(hitEffect, hitPos, this.gameObject.transform.rotation);

			tookMeleeDamage = true;
        }
    }
}
