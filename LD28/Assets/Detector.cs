using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Detector : MonoBehaviour {
	public Control ship;
	public List<Collectable> collectables = new List<Collectable>();
	
	public void OnTriggerEnter(Collider other){
		Collectable pickup = other.GetComponent<Collectable>();
		if(pickup != null && !collectables.Contains(pickup)){
			collectables.Add(pickup);
			pickup.attractor = ship;
		}
	}
	
	public void OnTriggerStay(Collider other){
		Collectable pickup = other.GetComponent<Collectable>();
		if(pickup && !collectables.Contains(pickup)){
			collectables.Add(pickup);
			pickup.attractor = ship;
		}
	}
	
	public void OnTriggerExit(Collider other){
		Collectable pickup = other.GetComponent<Collectable>();
		if(pickup != null){
			pickup.attractor = null;
			collectables.Remove(pickup);
		}
	}	
		
}
