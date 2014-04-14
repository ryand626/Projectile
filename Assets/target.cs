using UnityEngine;
using System.Collections;

public class target : MonoBehaviour {
	
	void OnCollisionStay(Collision target){
		print (target.gameObject.name);
		rigidbody.useGravity = true;
		//rigidbody.velocity = target.rigidbody.velocity * 20f;
	}
}
