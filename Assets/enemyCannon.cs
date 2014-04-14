using UnityEngine;
using System.Collections;

public class enemyCannon : MonoBehaviour {

	public GameObject player;
	public GameObject firePoint;

	public float initialVelocity;
	public float angle;

	public Vector3 distance;

	public float velMult;

	// Use this for initialization
	void Start () {

		StartCoroutine (fireLoop ());
	}
	
	// Update is called once per frame
	IEnumerator fireLoop () {
		while (true) {
			calculateAngle ();
			yield return new WaitForSeconds(2f);
			launch();
			yield return null;
		}
	}


	void calculateAngle(){
		initialVelocity = Vector3.Magnitude(firePoint.transform.position - transform.position) * velMult;
		distance =  firePoint.transform.position - player.transform.position;

		float v = initialVelocity * initialVelocity;
		float g = Physics.gravity.y;//Mathf.Abs(Physics.gravity.y);
		float x = distance.x;//Mathf.Abs(distance.x);
		float y = distance.y;//Mathf.Abs(distance.y);

		angle = Mathf.Atan ((v - Mathf.Sqrt (v * v - g * (g * x * x + 2 * y * v))) / (g * x));

		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle * Mathf.Rad2Deg));


		print (Mathf.Rad2Deg * angle);
	}

	void launch(){
		GameObject projectile = (GameObject)Instantiate (Resources.Load ("projectile"));
		projectile.transform.position = firePoint.transform.position;
		projectile.rigidbody.velocity = (firePoint.transform.position - transform.position) * velMult;

	}

}
