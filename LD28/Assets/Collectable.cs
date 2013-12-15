using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public Control attractor;
	public float mag = 100;
	public int size;
	
	public void FixedUpdate(){
		if(attractor != null){
			Vector3 a = attractor.transform.position;
			Vector3 dir = (a - transform.position).normalized;
			rigidbody.AddForce(dir * mag * Time.deltaTime, ForceMode.Impulse);
		}
	}
	
	
	public void Update(){
		if(attractor != null && Vector3.Distance(attractor.transform.position,transform.position) < 20.0f){
			attractor.AddToHold(this);
			GetCollected();
		}
	}
	
	public void GetCollected(){
		Destroy(gameObject);
	}
}
