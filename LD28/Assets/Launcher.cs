using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	
	public GameObject reticle;
	public void Update(){
		var mousePos = Input.mousePosition;
   		reticle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
		transform.LookAt(reticle.transform);
	}
	
	public void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position,reticle.transform.position);
	}
}
