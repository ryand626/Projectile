using UnityEngine;
using System.Collections;

public class oscillate : MonoBehaviour {

	public float scaleFactor;
	public float timeFactor;
	Vector3 origin;

	// Set initial position
	void Start () {
		origin = transform.position;
	}
	// make it oscillate
	void Update () {
		transform.position = origin + new Vector3(0f, Mathf.Sin(Time.time / timeFactor) * scaleFactor, 0f);
	}
}
