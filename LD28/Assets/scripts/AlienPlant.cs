using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AlienPlant : MonoBehaviour {

    public int eaten;
    public List<Vines> disabledVines = new List<Vines>();
	public float timeToLive = 300;
	public Queue<Collectable> toEat = new Queue<Collectable>();

    public void Start() {
        disabledVines = GetComponentsInChildren<Vines>().ToList();
    }

	public void Grow(Collectable col){
        eaten += 1;
		transform.localScale +=new Vector3(col.size/100.0f,col.size/100.0f,0);
        if (eaten == 5) {
            Vines v = disabledVines[0];
            v.enabled = true;
            disabledVines.Remove(v);
        }
	}
	
	public void Update(){
		timeToLive-=Time.deltaTime;
		
		if(timeToLive <= 0){
			Debug.Log("gameover");
		}


	}
	
	public void OnTriggerEnter(Collider other){
		Collectable pickup = other.GetComponent<Collectable>();
		if(pickup != null && !toEat.Contains(pickup)){
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
