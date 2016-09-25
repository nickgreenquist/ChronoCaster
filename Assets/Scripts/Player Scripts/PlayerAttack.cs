using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    // The object which will be shot from the gun
    //public GameObject bulletObject1;
    //public GameObject bulletObject2;
    //public Vector3 bulletOffset = new Vector3(.75f, .5f, 1);

    public int damage = 25;
    public float timeBetweenShots = 0.15f;
    public float range = 100;
    // The speed (in Unity units) that the object should be shot at

    float timer;
    Ray shotRay;
    RaycastHit shotHit;
    int shootableMask;
    ParticleSystem shotParticles;
    LineRenderer shotLine;
    AudioSource shotAudio;
    Light shotLight;
    float effectsDisplayTime = 0.2f;

    public bool gunType = true;
    public float coolDown;
    public float coolDownCounter = 120;

    bool upgraded = false;
    int upgradeTimer = 0;

    // Update is called once per frame
    void Awake()
    {

        coolDown = 15;
        shootableMask = LayerMask.GetMask("Shootable");
        shotParticles = GetComponent<ParticleSystem>();
        shotLine = GetComponent<LineRenderer>();
        shotAudio = GetComponent<AudioSource>();
        shotLight = GetComponent<Light>();
    }

    void Update()
    {



        //change the weapon
        //if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)	//change to normal weapon
        //{
        //    gunType = true;
        //    coolDown = 15;
        //}
        //if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)	//change to heavy weapon
        //{
        //    gunType = false;
        //    coolDown = 90;
        //}

        //shoot your gun

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenShots)					//player is holding fire button down
        {
            Shoot();
        }

        if (timer >= timeBetweenShots * effectsDisplayTime)
        {
            DisableShotEffects();
        }

        if (upgraded)
        {
            upgradeTimer++;
        }
        if (upgradeTimer > 240)
        {
            timeBetweenShots = .15f;
            upgraded = false;
            upgradeTimer = 0;
        }
    }

    public void DisableShotEffects()
    {
        shotLine.enabled = false;
        shotLight.enabled = false;
    }

    public void Shoot()
    {
        timer = 0f;

        shotAudio.Play();

        shotLight.enabled = true;

        shotParticles.Stop();
        shotParticles.Play();

        shotLine.enabled = true;
        shotLine.SetPosition(0, transform.position);

        shotRay.origin = transform.position;
        shotRay.direction = transform.forward;

        if (Physics.Raycast(shotRay, out shotHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shotHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            shotLine.SetPosition(1, shotHit.point);
        }
        else
        {
            shotLine.SetPosition(1, shotRay.origin + shotRay.direction * range);
        }
    }

    public void setUpgradeSpeed()
    {
        upgraded = true;
        timeBetweenShots = .08f;
    }
}
