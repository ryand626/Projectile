using UnityEngine;
using System.Collections;

public class enemyCannon : MonoBehaviour {

	public GameObject player;
	public GameObject firePoint;

	public float initialVelocity;
	public float angle;

	public Vector3 distance;

	public float velMult;

	private int health;

	// Use this for initialization
	void Start () {
		health = 10;

		StartCoroutine (fireLoop ());
	}
	
	// Update is called once per frame
	IEnumerator fireLoop () {
		while (health > 0) {
			calculateAngle ();
			yield return new WaitForSeconds(2f);
			launch();
			yield return null;
		}
		gameObject.AddComponent<Rigidbody> ();
		rigidbody.useGravity = true;
		Destroy (gameObject.GetComponent<oscillate> ());
	}


	void calculateAngle(){
		initialVelocity = Vector3.Magnitude(firePoint.transform.position - transform.position) * velMult;
		distance =  firePoint.transform.position - player.transform.position;

		float v = initialVelocity * initialVelocity;
		float g = Physics.gravity.y;
		float x = distance.x;
		float y = distance.y;

		angle = Mathf.Atan ((v - Mathf.Sqrt (v * v - g * (g * x * x + 2 * y * v))) / (g * x));

		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle * Mathf.Rad2Deg));


		print (Mathf.Rad2Deg * angle);
	}

	void launch(){
		GameObject projectile = (GameObject)Instantiate (Resources.Load ("projectile"));
		projectile.transform.position = firePoint.transform.position;
		projectile.rigidbody.velocity = (firePoint.transform.position - transform.position) * velMult;

	}

	void OnCollisionEnter(){
		health--;
	}

}
