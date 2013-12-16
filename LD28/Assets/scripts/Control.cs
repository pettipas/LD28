﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Control : MonoBehaviour {
	public float speed;
	public float mult = 1;
	public int holdlimit = 10;
	public int hits = 0;
	public Detector detector;
	public Collider detectorCollider;
	public List<string> hold = new List<string>();
	public List<GameObject> prefabs = new List<GameObject>();
	
	public Transform unloadPoint;
    public Transform beam;
	public static Control instance;
    public List<GameObject> life = new List<GameObject>();
	
	public GUIText text;
    public AudioSource beamsound;

	public void Awake(){
		instance = this;
	}
	
	public bool AtLimit{
		get{
			return hold.Count >= holdlimit;
		}
	}
	bool unloading;
	bool deathStarted;
	public void Update(){
        if (hits >= life.Count && !deathStarted) {
			deathStarted = true;
			collider.isTrigger = false;
			rigidbody.useGravity = true;
			StartCoroutine(Death());
		}

        if (hits >= life.Count) {
			Debug.Log("gameover");
			rigidbody.AddForce(-transform.up *100*Time.deltaTime,ForceMode.Impulse);
		}
	}
	bool showing;
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
		bool beam = Input.GetKey(KeyCode.E) || Input.GetMouseButton(1);
		
		if(Input.GetKey(KeyCode.G)){
			Application.LoadLevel("start");
		}
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
		
		if(AtLimit){
			text.text = "CARGO BAY FULL. GO FEED THE PLANT!";
		}else {
			text.text = "READY FOR HUMANS";
		}
		
		if(beam && !AtLimit){
			BeamOn();
		}else {
			BeamOff();
		}

        if (hits > 0 && hits <= life.Count-1) {
            for (int i = 0; i < hits; i++) {
                life[i].renderer.enabled = false;
                life[i].light.enabled = false;
            }
        }
	}
	
	public IEnumerator ShowMessage(string message){
		text.text = message;
		yield return new WaitForSeconds(2);
		showing = false;
		text.enabled = false;
	}
	
	public IEnumerator Death(){
        for (int i = 0; i < hits; i++) {
            life[i].renderer.enabled = false;
            life[i].light.enabled = false;
        }
		yield return new WaitForSeconds(5.0f);
		Destroy(gameObject);
		Application.LoadLevel("gameover");
	}
	
	public IEnumerator Unload(){
		for(int i=0; i < hold.Count; i++){
			GameObject go = prefabs.Find(c => c.name == hold[i]);
			GameObject falling = Instantiate(go, unloadPoint.transform.position, Quaternion.identity) as GameObject;
			falling.name = go.name;
			yield return new WaitForSeconds(0.2f);
		}
		hold.Clear();
		unloading = false;
		yield break;
	}
	
	public void BeamOn(){
        if (!beamsound.isPlaying) {
            beamsound.Play();
        }
		detectorCollider.enabled = true;
        beam.renderer.enabled = true;
	}
	
	public void BeamOff(){
        beamsound.Stop();
        beam.renderer.enabled = false;
		detector.collectables.ForEach(c=>{
			c.attractor = null;
		});
		detector.collectables.Clear();
		detectorCollider.enabled = false;
	}
}
