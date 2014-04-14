using UnityEngine;
using System.Collections;

public class sploosh : MonoBehaviour {

	void OnCollisionEnter(Collision target){
		Destroy (target.gameObject);
		print ("splooosh");
	}
}
