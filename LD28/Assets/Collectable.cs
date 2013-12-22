using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public Control attractor;
	public float mag = 100;
	public int size;
	public ParticleSystem system;
	public bool started;
	public void Start(){
		system = GetComponent<ParticleSystem>();
	}
	
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
	
	public IEnumerator Death(float val){
		system.Emit(Mathf.RoundToInt(val-20));
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}
	
	public void OnCollisionEnter(Collision col){
		if(col.relativeVelocity.y > 30 && !started){
			started = true;
			StartCoroutine(Death(col.relativeVelocity.y));
		}
	}
	
	public void GetCollected(){
		Destroy(gameObject);
	}
}
