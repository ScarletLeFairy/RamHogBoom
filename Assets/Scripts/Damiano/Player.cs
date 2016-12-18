using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public static List<PlayerControllerAdv> players = new List<PlayerControllerAdv>();

	Rigidbody rigid;
	Collider border;

	public float boost = 400;

	public float speed = 6f;
	public float maxspeed = 6f;
	public float dynamic_friction = 0.6f;
	public float static_friction = 0.6f;
	public float turn = 6f;
	Vector2 joyDirL = Vector2.zero;
	Vector2 joyDirR = Vector2.zero;
	float stun = 0;

	Dashing dash = null;

    private GameObject ball;

    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    public Slot slot;
	public enum Slot{
		Player_1,
		Player_2,
		Player_3,
		Player_4,
		Player_5,
		Player_6,
		Player_7,
		Player_8
	}

	public Faction faction;
	public enum Faction{
		HOG,
		RAM
	}

	GameObject ark;

	void Awake() {
		rigid = GetComponent<Rigidbody>();
		border = GetComponent<Collider> (); 

		ark = transform.Find("Ark").gameObject;

	}
		
	void AddForce(Vector3 dir, float force, float mass = 1){
		float acceleration = force / mass;
		rigid.velocity += dir * acceleration * Time.fixedDeltaTime;

		/*last_acceleration = acceleration
			position += velocity * time_step + ( 0.5 * last_acceleration * time_step^2 )
			new_acceleration = force / mass 
			avg_acceleration = ( last_acceleration + new_acceleration ) / 2
			velocity += avg_acceleration * time_step*/
	}

	// Update is called once per frame
	void FixedUpdate () {

		//Vector3 moveDir = Vector3.forward;
		Vector3 moveDir = Vector3.forward * joyDirL.x + Vector3.right * joyDirL.y;

		//GRAVITY
		AddForce(Vector3.down, 9.81f);

		//MOVEMENT

		if (moveDir.magnitude != 0 && stun <= 0) {
			Quaternion targetRotation = Quaternion.LookRotation (moveDir, Vector3.up);
			float factor = 1 - Quaternion.Angle (transform.rotation, targetRotation) / 360f;
			Quaternion deltaRotation = Quaternion.Slerp (transform.rotation, targetRotation, Mathf.Pow (turn, factor) * Time.deltaTime);

			rigid.MoveRotation (deltaRotation);


			AddForce(moveDir, speed);
			//rigid.velocity += moveDir * acceleration * Mathf.Pow (Time.fixedDeltaTime, 1);

			//MAXSPEED
			/*if (rigid.velocity.magnitude > maxspeed) {
				rigid.velocity = rigid.velocity.normalized * maxspeed;
			}*/
		} else {
			//rigid.velocity = Vector3.zero;
		}

		//FRICTION

		rigid.velocity += (-(rigid.velocity * dynamic_friction) - rigid.velocity.normalized * (rigid.velocity.magnitude - static_friction)) * Time.fixedDeltaTime;


		if (dash != null) {

			rigid.velocity = Vector3.zero;

			if (dash.time + 0.25 > Time.time) {
				//rigid.AddForce (charge.direction * charge.power, ForceMode.VelocityChange);
				rigid.velocity = dash.direction * boost * Mathf.Pow(Time.fixedDeltaTime, 1);
				rigid.MoveRotation (Quaternion.LookRotation(dash.direction, Vector3.up));
			} else {
				dash = null;
				stun = 0.2f;
			}
		}


		if (stun >= 0) {
			stun -= Time.fixedDeltaTime;
			rigid.velocity = Vector3.zero;
		}


		//PREVENT COLLISION

		float adjustment = border.bounds.extents.y;
		/*if (border is CapsuleCollider) {
			adjustment = ((CapsuleCollider)border).radius;
		}*/
			

		Vector3 distance = rigid.velocity.normalized * adjustment;

		Debug.DrawLine(transform.position + Vector3.up, transform.position + Vector3.up + distance +  rigid.velocity * Time.fixedDeltaTime*10, Color.green);

		RaycastHit hit;
		if (Physics.SphereCast(transform.position + Vector3.up, adjustment, rigid.velocity.normalized, out hit, rigid.velocity.magnitude*Time.fixedDeltaTime*1.1f, Physics.DefaultRaycastLayers , QueryTriggerInteraction.Ignore)){
//			Debug.Log ("Found an object - distance: " + hit.distance + " " + hit.collider.gameObject.name);	
			//rigid.AddForce (-rigid.velocity, ForceMode.VelocityChange);
			//rigid.velocity = Vector3.zero;
			//transform.position = transform.position + rigid.velocity;
		}

	

		RefreshArk();
	}

	void Update () {
		joyDirL = new Vector2 (GetLeftStickY(), GetLeftStickX());
		joyDirR = new Vector2 (GetRightStickY(), GetRightStickX());

        //Debug.DrawLine(transform.position, transform.position + ark.transform.rotation * Vector3.up*20, Color.green);



        if (ball != null)
        {
            ball.transform.position = new Vector3(transform.position.x, transform.position.y + 2.2f, transform.position.z);
        }

        if (GetRightBumper())
        {
            if (ball != null)
            {
                // TODO throw ball
                ThrowBall();
                Debug.Log("Hello World!");
            }
            else
            {
                if (dash == null)
                {
                    dash = new Dashing(ark.transform.rotation * Vector3.up, Time.time);
                }
            }
        }
	}

    private void ThrowBall()
    {
        ball.GetComponent<BallBehaviour>().GetThrown();

        //ball.GetComponent<Rigidbody>().AddForce(transform.forward + Vector3.up * 0.2f, 20, 0.15f);
        GravityEnhancer grav = ball.GetComponent<GravityEnhancer>();
        grav.Reset();
        Vector3 dir = transform.forward + Vector3.up * 0.2f;
        ball.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        grav.AddForce(dir, 7, 0.15f);
        grav.gravity = true;
                
        ball = null;
    }

    public void PickUpBall(GameObject b)
    {
        ball = b;
    }

    public void GetDashed()
    {
        stun = 0.2f;
        // loose ball in direction fo dash
        if (ball != null)
        {
            ball.GetComponent<BallBehaviour>().GetThrown();

            GravityEnhancer grav = ball.GetComponent<GravityEnhancer>();
            grav.Reset();
            grav.AddForce(transform.forward + Vector3.up * 0.2f, 5, 0.15f);
            grav.gravity = true;

            
            ball = null;
        }        
    }

    int GetControllerID(){

		int id = -1;

		switch(slot){
		case Slot.Player_1:
			id = 1;
			break;

		case Slot.Player_2:
			id = 2;
			break;

		case Slot.Player_3:
			id = 3;
			break;

		case Slot.Player_4:
			id = 4;
			break;

		case Slot.Player_5:
			id = 5;
			break;

		case Slot.Player_6:
			id = 6;
			break;

		case Slot.Player_7:
			id = 7;
			break;

		case Slot.Player_8:
			id = 8;
			break;
		}

		return id;
	}

	bool GetRightBumper(){

		switch (GetControllerID()){
		case 1: return Input.GetKeyDown(KeyCode.Joystick1Button5);
		case 2: return Input.GetKeyDown(KeyCode.Joystick2Button5);
		case 3: return Input.GetKeyDown(KeyCode.Joystick3Button5);
		case 4: return Input.GetKeyDown(KeyCode.Joystick4Button5);
		case 5: return Input.GetKeyDown(KeyCode.Joystick5Button5);
		case 6: return Input.GetKeyDown(KeyCode.Joystick6Button5);
		case 7: return Input.GetKeyDown(KeyCode.Joystick7Button5);
		case 8: return Input.GetKeyDown(KeyCode.Joystick8Button5);
			// Unity does not support buttons for more than 8 joysticks
		default: return false;
		}
	}

	void RefreshArk(){
		//ARK
		Vector3 lookDir = Vector3.forward * joyDirR.x + Vector3.right * joyDirR.y;
		if (lookDir.magnitude != 0) {
			ark.gameObject.GetComponent<Renderer>().enabled = true;

			Quaternion targetRotation = Quaternion.LookRotation (lookDir, Vector3.up) * Quaternion.LookRotation (Vector3.up, Vector3.forward);
			float factor = 1 - Quaternion.Angle( ark.transform.rotation, targetRotation )/360f;
			Quaternion deltaArk = Quaternion.Slerp(ark.transform.rotation, targetRotation, Mathf.Pow(turn*2, factor) * Time.deltaTime);

			//Quaternion deltaArk = Quaternion.LookRotation (lookDir, Vector3.up) * Quaternion.LookRotation (Vector3.up, Vector3.forward);
			ark.transform.rotation = deltaArk;
			ark.transform.position = transform.position + deltaArk * new Vector3 (0, 1f, 0.25f);
		} else {
			ark.gameObject.GetComponent<Renderer>().enabled = false;

			Quaternion deltaArk = Quaternion.LookRotation (transform.forward, Vector3.up) * Quaternion.LookRotation (Vector3.up, Vector3.forward);
			ark.transform.rotation = deltaArk;
			ark.transform.position = transform.position + deltaArk * new Vector3 (0, 1f, 0.25f);
		}
	}

	float GetLeftStickX()
	{
		int id = GetControllerID ();
		if (id < 1 || id > 8)
		{
			Debug.Log("Invalid controller number");
			return 0;
		}
		return Input.GetAxis("P" + id + "LeftStickX");
	}

	float GetLeftStickY()
	{
		int id = GetControllerID ();
		if (id < 1 || id > 8)
		{
			Debug.Log("Invalid controller number");
			return 0;
		}
		return Input.GetAxis("P" + id + "LeftStickY");
	}

	float GetRightStickX()
	{
		int id = GetControllerID ();
		if (id < 1 || id > 8)
		{
			Debug.Log("Invalid controller number");
			return 0;
		}
		return Input.GetAxis("P" + id + "RightStickX");
	}

	float GetRightStickY()
	{
		int id = GetControllerID ();
		if (id < 1 || id > 8)
		{
			Debug.Log("Invalid controller number");
			return 0;
		}
		return Input.GetAxis("P" + id + "RightStickY");
	}


}
	
class Dashing{

	public Vector3 direction;
	public float time;
	public float power = 1;

	public Dashing(Vector3 direction, float time){
		this.direction =  direction;
		this.time = time;
	}
}