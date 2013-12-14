using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Control : MonoBehaviour {
	public float speed;
	public float mult = 1;
	public int holdlimit = 10;
	
	public Detector detector;
	public Collider detectorCollider;
	public List<string> hold = new List<string>();
	public List<GameObject> prefabs = new List<GameObject>();
	
	public Transform unloadPoint;
	
	public bool AtLimit{
		get{
			return hold.Count >= holdlimit;
		}
	}
	bool unloading;
	
	public void AddToHold(Collectable col){
		if((hold.Count + col.size) <=holdlimit){
			hold.Add(col.name);
		}
	}
	
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		bool boost = Input.GetKey(KeyCode.LeftShift ) || Input.GetKey(KeyCode.RightShift);
		bool opendoors = Input.GetKey(KeyCode.Space);
		bool beam = Input.GetMouseButton(1);
		
		
		if(opendoors && hold.Count > 0 && !unloading){
			unloading = true;
			StartCoroutine(Unload());
		}
		
		if(boost) {
			mult = 3.0f;
		}else {
			mult = 1.0f;
		}
		
		rigidbody.AddForce(new Vector3(x,y/2.0f,0) * (speed * mult) *Time.deltaTime, ForceMode.Impulse);
		
		if(beam && !AtLimit){
			BeamOn();
		}else {
			BeamOff();
		}
	
	}
	
	public IEnumerator Unload(){
		for(int i=0; i < hold.Count; i++){
			GameObject go = prefabs.Find(c => c.name == hold[i]);
			GameObject falling = Instantiate(go, unloadPoint.transform.position, Quaternion.identity) as GameObject;
			falling.name = go.name;
			yield return new WaitForSeconds(0.3f);
		}
		hold.Clear();
		unloading = false;
		yield break;
	}
	
	public void BeamOn(){
		detectorCollider.enabled = true;
	}
	
	public void BeamOff(){
		detector.collectables.ForEach(c=>{
			c.attractor = null;
		});
		detector.collectables.Clear();
		detectorCollider.enabled = false;
	}
}
