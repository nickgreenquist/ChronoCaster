using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;
    public float jumpForce = 250.0f;
    public float turnSmoothing = 15f;
    public bool isTouchingGround;
	public float speedStat;
	public float speedStatReal;

    Vector3 movement;
    public Animator anim;
    Rigidbody playerRigidbody;

	public GameObject camera;

	public bool moving;

	public GameObject teleportSpell;
	public GameObject movementTrackerSpell;
	public SpellEffect spellEffect;


    //Set up the components
    void Awake()
    {
		speedStat = 5;
		speedStatReal = 5;
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
		camera = GameObject.Find ("Main Camera");
		movementTrackerSpell = (GameObject)Instantiate(teleportSpell, this.gameObject.transform.position, this.gameObject.transform.rotation);
		spellEffect = movementTrackerSpell.GetComponent<SpellEffect>();
		spellEffect.duration = 12000000;
		spellEffect.active = true;
		spellEffect.tracker = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		//anim.animation["Run"].speed = speedStat / 5;
		anim.speed = speedStatReal / 5;
		//Move(h, v);
        //Rotating(h, v);
        Jumping();

		Vector3 pos = Input.mousePosition;
		//pos.z = 18;
		pos.z = Vector3.Distance(camera.transform.position, this.transform.position);
		pos = Camera.main.ScreenToWorldPoint(pos);
		pos.y = transform.position.y;
		spellEffect.spellP = pos;
		transform.LookAt(pos);

		//mouse movement
		if(Input.GetMouseButton(0))
		{
			moving = true;
			anim.SetFloat("Run",1);
		}
		if(Input.GetMouseButtonDown(0))
		{
			moving = true;
			anim.SetFloat("Run",1);
		}
		if(!Input.GetMouseButton(0))
		{
			moving = false;
			anim.SetFloat("Run",0);
		}

		if(this.transform.position.y > 5.7f)
		{
			Vector3 tempPos = this.transform.position;
			tempPos.y -= .1f;
			this.transform.position = tempPos;
		}
    }


    void Move(float h, float v)
    {
        //Sets the value of the movement vector, 0f for no movement in the y- axis
        movement.Set(h, 0f, v);

        //Movement is normalized, multipled by speed and dealtatime
        movement = movement.normalized * speed * Time.deltaTime;

        //Adds movemtn to current position
        //Uses rigidbody to move with physics
        playerRigidbody.MovePosition(transform.position + movement);
    }


    void Rotating(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            // Create a new vector of the horizontal and vertical inputs.
            Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

            // Create a rotation based on this new vector assuming that up is the global y axis.
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            // Create a rotation that is an increment closer to the target rotation from the player's rotation.
            Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

            // Change the players rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            isTouchingGround = false;
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isTouchingGround = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isTouchingGround = false;
        }
    }
}
