using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {
	public Component ship;
	public float speed;
	public float rotationSpd;
	public Vector3 targetAngle = new Vector3 (0f, 0f, 0f);
	private Vector3 currentAngle;

	// Use this for initialization
	void Start () {
		currentAngle = ship.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		//forward/backward movement
		if (Input.GetKey (KeyCode.W)) {
			ship.transform.Translate (Vector3.forward * Time.deltaTime * speed);
		} else if (Input.GetKey (KeyCode.S)) {
			ship.transform.Translate (Vector3.back * Time.deltaTime * speed);
		} 

		//lateral movement
		if (Input.GetKey (KeyCode.Q)) {
			ship.transform.Translate (Vector3.left * Time.deltaTime * speed);
		} else if (Input.GetKey (KeyCode.E)) {
			ship.transform.Translate (Vector3.right * Time.deltaTime * speed);
		} 

		//rotational movement
		if (Input.GetKey (KeyCode.A)) {
			ship.transform.Rotate (Vector3.down, Time.deltaTime * rotationSpd, Space.Self);
		} else if (Input.GetKey (KeyCode.D)) {
			ship.transform.Rotate (Vector3.up, Time.deltaTime * rotationSpd, Space.Self);
		} else {
			targetAngle = new Vector3 (0f, 0f, 0f);
		}

		//vertical movement
		if (Input.GetKey (KeyCode.LeftShift)) {
			ship.transform.Translate (Vector3.up * Time.deltaTime * speed);
		} else if (Input.GetKey (KeyCode.LeftControl)) {
			ship.transform.Translate (Vector3.down * Time.deltaTime * speed);
		}

	}
}
