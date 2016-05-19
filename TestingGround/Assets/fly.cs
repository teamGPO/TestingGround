using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {
	public Component ship;
	public Rigidbody missile;
	public Transform missilePos;
	public float missileSpd;
	public float speed, acceleration;
	public float rotationSpd, liftingSpd;
	public float maxThrust, minThrust;
	public Vector3 targetAngle = new Vector3 (0f, 0f, 0f);
	private Vector3 currentAngle;

	// Use this for initialization
	void Start () {
		currentAngle = ship.transform.eulerAngles;
		speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//forward/backward movement
		if (Input.GetKey (KeyCode.LeftShift)) {
			//ship.transform.Translate (Vector3.forward * Time.deltaTime * speed);
			if ( speed < maxThrust)
				speed += Time.deltaTime * acceleration;
			
		} else if (Input.GetKey (KeyCode.LeftControl)) {
			//ship.transform.Translate (Vector3.back * Time.deltaTime * speed);
			if (speed > -maxThrust)
				speed -= Time.deltaTime * acceleration;
		}
		ship.transform.Translate (Vector3.forward * Time.deltaTime * speed);


		//lateral movement
		if (Input.GetKey (KeyCode.Q)) {
			ship.transform.Translate (Vector3.left * Time.deltaTime * speed);
		} else if (Input.GetKey (KeyCode.E)) {
			ship.transform.Translate (Vector3.right * Time.deltaTime * speed);
		} 

		//rotational movement
		if (Input.GetKey (KeyCode.A)) {
			//ship.transform.Rotate (Vector3.down, Time.deltaTime * rotationSpd, Space.Self);
			targetAngle = new Vector3 (targetAngle.x, targetAngle.y - Time.deltaTime*rotationSpd, 30f);
		} else if (Input.GetKey (KeyCode.D)) {
			//ship.transform.Rotate (Vector3.up, Time.deltaTime * rotationSpd, Space.Self);
			targetAngle = new Vector3 (targetAngle.x, targetAngle.y + Time.deltaTime*rotationSpd, -30f);
		} else {
			targetAngle = new Vector3 (targetAngle.x, targetAngle.y, 0f);
		}
		currentAngle = new Vector3 (
			Mathf.LerpAngle (currentAngle.x, targetAngle.x, Time.deltaTime),
			Mathf.LerpAngle (currentAngle.y, targetAngle.y, Time.deltaTime),
			Mathf.LerpAngle (currentAngle.z, targetAngle.z, Time.deltaTime));
		ship.transform.eulerAngles = currentAngle;

		//vertical movement
		if (Input.GetKey (KeyCode.S)) {
			//ship.transform.Translate (Vector3.up * Time.deltaTime * speed);
			targetAngle = new Vector3 (targetAngle.x - Time.deltaTime*liftingSpd, targetAngle.y, targetAngle.z);
		} else if (Input.GetKey (KeyCode.W)) {
			//ship.transform.Translate (Vector3.down * Time.deltaTime * speed);
			targetAngle = new Vector3 (targetAngle.x + Time.deltaTime*liftingSpd, targetAngle.y, targetAngle.z);
		} else {
			targetAngle = new Vector3 (targetAngle.x, targetAngle.y, 0f);
		}


		//firing
		if (Input.GetKeyUp (KeyCode.Space)) {
			//Debug.Log ("Space hit");
			Rigidbody clone = Instantiate (missile, missilePos.position, missilePos.rotation) as Rigidbody;
			//clone.velocity = ship.transform.TransformDirection (Vector3.forward * missileSpd);
			clone.AddForce (ship.transform.forward * missileSpd);// = transform.TransformDirection (Vector3.forward * missileSpd);
			//clone.velocity = missilePos.forward*missileSpd;

		}

		

	}
}
