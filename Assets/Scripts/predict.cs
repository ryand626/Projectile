using UnityEngine;
using System.Collections;
// Revised from gfoot's post: http://forum.unity3d.com/threads/143636-Projectile-prediction-line?p=985266&viewfull=1#post985266
public class predict : MonoBehaviour {
	public Vector3 initialVelocity;
	public Vector3 initialPosition;
	public int numSteps;
	public float spacing;

	void Awake(){
		numSteps = 500;
		spacing = 1.0f;
	}

	public void UpdateTrajectory()	{

		float timeDelta = spacing / initialVelocity.magnitude;

		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(numSteps);
		lineRenderer.material.SetTextureScale ("_MainTex", new Vector2(numSteps/5, 1f));

		Vector3 position = initialPosition;
		Vector3 velocity = initialVelocity;
		
		for (int i = 0; i < numSteps; ++i){
			lineRenderer.SetPosition(i, position);

			position += velocity * timeDelta + 0.5f * Physics.gravity * timeDelta * timeDelta;
			velocity += Physics.gravity * timeDelta;
		}
	}
}
