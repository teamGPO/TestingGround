using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
	public GameObject proj;
	public float maxLiveTime;
	// Use this for initialization
	void Start () {
		Destroy (proj, maxLiveTime);
	}

}
