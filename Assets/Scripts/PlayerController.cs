using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private CharacterController controller;
	private Vector3 moveVector;

	private float jumpPower= 5.0f;
	private float gravity = 12.0f;
	private float verticalVelocity = 0.0f;
	private float speed = 5.0f;
	private float animationDuration = 2.0f;
	private float startTime;

	public float timeToWait = 5;
	private float wait = 0;
	private float newTime = 0;
	private float oldTime = 0;
	private float timeTest = 0;

	private int shieldCounter = 0;

	private Light lt;

	public GameObject targetedMesh1;
	public GameObject targetedMesh2;
	private bool invulnerable = false;
	private bool isDead = false;

	// Use this for initialization
	void Start () {
		lt = GetComponent <Light>();
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("Time is " + Time.time); 
		Debug.Log ("Speed is " + speed);
		if (isDead) 
		{
			return;
		}

		if (Time.time - startTime < animationDuration) 
		{
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
	
		moveVector = Vector3.zero;



		if (controller.isGrounded)
		{
			verticalVelocity = -0.05f;
		} 
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		if (Input.GetButton ("Jump") && controller.isGrounded) 
		{
			Debug.Log ("Jump");
			moveVector.y = jumpPower;
		}
		//X - Left Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		if (Input.GetMouseButton (0))
		{
			// check if touch screen on right
			if (Input.mousePosition.x > Screen.width / 2)
				moveVector.x = speed;
			else
				moveVector.x = -speed;
		}
		//Y - UP Down
		moveVector.y = verticalVelocity;
		//Z - Forward Backward
		moveVector.z = speed;
		controller.Move (moveVector * Time.deltaTime);

		if (moveVector.y < -10f) {
			Death ();
		}
	}

	public void SetSpeed(float speedModifier)
	{
		speed = 5.0f + speedModifier;
	}
		
	// Called on every collision with something
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		
		if (hit.point.z > transform.position.z + controller.radius && hit.gameObject.tag == "Enemy") 
		{
			Death ();
		}
		if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Invulnerability") 
		{

			StartCoroutine (Invulnerable());
			//PowerUp();
			Invulnerable ();
			Destroy (hit.gameObject);
		}

	}

	public IEnumerator Invulnerable()
	{
		invulnerable = true;


		/*oldTime = Time.time;
		newTime = oldTime + 5;
		timeTest = newTime - oldTime;


		while (newTime <= oldTime) 
		{
			timeTest = newTime - oldTime;
			Debug.Log ("power Up timer " + timeTest);
			targetedMesh1.GetComponent<MeshRenderer>().enabled = true;
			targetedMesh2.GetComponent<MeshRenderer>().enabled = true;

		}*/
		if (invulnerable) 
		{
			//lt.intensity = 200;
			targetedMesh1.GetComponent<MeshRenderer>().enabled = true;
			targetedMesh2.GetComponent<MeshRenderer>().enabled = true;
			yield return new WaitForSecondsRealtime (5);

		}

		invulnerable = false;

		if (!invulnerable)
		{
			targetedMesh1.GetComponent<MeshRenderer>().enabled = false;
			targetedMesh2.GetComponent<MeshRenderer>().enabled = false;
			//lt.intensity = 0;
		}
	}

	/*private void PowerUp()
	{
		shieldCounter += 1;
		Debug.Log (shieldCounter);
		invulnerable = true;
		if (invulnerable) 
		{
			lt.intensity = 200;


				shieldCounter -= 1;
				Debug.Log (shieldCounter);
				if (shieldCounter == 0) {
					invulnerable = false;
					Debug.Log (invulnerable);


			}
		}


		if (!invulnerable)
		{
			lt.intensity = 0;
		}
	}*/



	private void Death()
	{
		
		if (!invulnerable) {
			Debug.Log ("DEAD");
			isDead = true;
			GetComponent<Score> ().OnDeath ();
		}
	}
		
}
