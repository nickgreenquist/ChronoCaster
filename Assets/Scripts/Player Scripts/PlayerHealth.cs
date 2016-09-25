using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth;
    public float currentHealth;
	public int health;
    bool flash = false;
    int flashCounter = 0;

	public GameObject playerC;
	public PlayerMovement playerMovement;

	public int restartGame;

	public int deathCounter;

    // Use this for initialization
    void Start()
    {
		health = 5;
		maxHealth = health * 20;
		currentHealth = maxHealth;
        //playerHit = GetComponent<AudioSource>();

		playerC = GameObject.Find ("Player");
		playerMovement = playerC.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
		maxHealth = health * 20;
		if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        if (flashCounter > 20)
        {
            flash = false;
            flashCounter = 0;
        }

		if(currentHealth <= 0)
		{
			restartGame++;
		}
		if(restartGame > 90)
		{
			Application.LoadLevel("SciFi Level");
		}

    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;

        //flash screen when taking damage
        if (damage > 0)
        {
            flash = true;
        }

        if (currentHealth <= 0)
        {
			playerMovement.anim.SetBool("Dead", true);
        }
    }

    void OnGUI()
    {
        if (flash)
        {
            flashCounter++;

            GUIStyle style = new GUIStyle();
            Texture2D texture = new Texture2D(128, 128);
            for (int y = 0; y < texture.height; ++y)
            {
                for (int x = 0; x < texture.width; ++x)
                {
                    Color color = new Color(1, 0, 0, .3f);
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
            style.normal.background = texture;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), new GUIContent(""), style);
        }
    }
}
