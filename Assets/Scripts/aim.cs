using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {
	public predict prediction;
	public fire shoot;
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			transform.Rotate(0f,0f,1f);
			prediction.initialPosition = transform.FindChild("launchpoint").transform.position;
			prediction.initialVelocity = (gameObject.transform.FindChild("barrel").position - gameObject.transform.position) * shoot.launchVelocity;
			prediction.UpdateTrajectory();
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			transform.Rotate(0f,0f,-1f);
			prediction.initialPosition = transform.FindChild("launchpoint").transform.position;
			prediction.initialVelocity = (gameObject.transform.FindChild("barrel").position - gameObject.transform.position) * shoot.launchVelocity;
			prediction.UpdateTrajectory();
		}

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			shoot.launchVelocity += .1f;
			prediction.initialPosition = transform.FindChild("launchpoint").transform.position;
			prediction.initialVelocity = (gameObject.transform.FindChild("barrel").position - gameObject.transform.position) * shoot.launchVelocity;
			prediction.UpdateTrajectory();
		}
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			shoot.launchVelocity -= .1f;
			prediction.initialPosition = transform.FindChild("launchpoint").transform.position;
			prediction.initialVelocity = (gameObject.transform.FindChild("barrel").position - gameObject.transform.position) * shoot.launchVelocity;
			prediction.UpdateTrajectory();
		}	

	}
}
