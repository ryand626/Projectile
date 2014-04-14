using UnityEngine;
using System.Collections;

public class oscillate : MonoBehaviour {

	public float scaleFactor;
	public float timeFactor;
	Vector3 origin;


	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = origin + new Vector3(0f, Mathf.Sin(Time.time / timeFactor) * scaleFactor, 0f);
		print (transform.position);
	}
}
