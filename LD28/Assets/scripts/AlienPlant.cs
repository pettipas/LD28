using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienPlant : MonoBehaviour {
	
	
	public Queue<Collectable> toEat = new Queue<Collectable>();
	
	public void Grow(Collectable col){
		transform.localScale +=new Vector3(col.size/10.0f,col.size/10.0f,0);
	}
	
	public void OnTriggerEnter(Collider other){
		Collectable pickup = other.GetComponent<Collectable>();
		if(!toEat.Contains(pickup)){
			toEat.Enqueue(pickup);
		}
	}
	
	public void LateUpdate(){
		if(toEat.Count > 0){
			Collectable col = toEat.Dequeue();
			Grow(col);
			Destroy(col.gameObject);
		}
	}
}
