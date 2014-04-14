using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	public GameObject projectile;
	public float launchVelocity;

	void Awake(){
		projectile = null;
	}


	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			projectile = (GameObject)Instantiate(Resources.Load("projectile"));
			projectile.transform.position = transform.FindChild("launchpoint").transform.position;
			projectile.rigidbody.velocity = (gameObject.transform.FindChild("barrel").position - gameObject.transform.position) * launchVelocity;
		}
	}
}
