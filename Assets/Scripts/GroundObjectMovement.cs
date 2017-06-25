using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectMovement : MonoBehaviour {


	private bool dirRight = true;
	public float speed = 1.5f;
	public float distance = 1.5f;

//	public Vector3 targetAngle = new Vector3 (360f, 0f, 0f);
//	private Vector3 currentAngle = Vector3;
	// Use this for initialization
	void Start () {
//		currentAngle = transform.eulerAngles;
	}

	// Update is called once per frame
	void Update () {
//		currentAngle = new Vector3 (
//			Mathf.LerpAngle (currentAngle.x, targetAngle.x, Time.deltaTime),
//			Mathf.LerpAngle (currentAngle.y, targetAngle.y, Time.deltaTime),
//			Mathf.LerpAngle (currentAngle.z, targetAngle.z, Time.deltaTime)
//		);
//		transform.eulerAngles = currentAngle;

		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

		if (transform.position.x >= distance)
			dirRight = false;

		if (transform.position.x <= -distance)
			dirRight = true;
	}
}
