using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	public float speed;
	public float mult = 1;
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		bool boost = Input.GetKey(KeyCode.Space);
		
		if(boost) {
			mult = 3.0f;
		}else {
			mult = 1.0f;
		}
		
		rigidbody.AddForce(new Vector3(x,y/2.0f,0) * (speed * mult) *Time.deltaTime, ForceMode.Impulse);
		
	}
}
