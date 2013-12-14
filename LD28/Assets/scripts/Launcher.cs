using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	
	public GameObject reticle;
	public GameObject projectile;
	
	public void Update(){
		var mousePos = Input.mousePosition;
   		Vector3 p= Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
		reticle.transform.position  = new Vector3(p.x,p.y,0);
		transform.LookAt(reticle.transform);
		
		if(Input.GetMouseButtonUp(0)){
			Instantiate(projectile,transform.position,transform.rotation);
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position,reticle.transform.position);
	}
}
