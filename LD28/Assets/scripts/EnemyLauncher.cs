using UnityEngine;
using System.Collections;

public class EnemyLauncher : MonoBehaviour {

	public GameObject target;
	public GameObject projectile;
	public float range;
	bool started;
	
	public void Update(){
		if(target != null && !started){
			started = true;
			StartCoroutine(ShootWhenClose());
		}
		if(target != null){
			transform.LookAt(target.transform);
		}
	}
	
	
	public IEnumerator ShootWhenClose(){
		while(target != null){
			if(Vector3.Distance(target.transform.position,transform.position) < range){
				Instantiate(projectile,transform.position,transform.rotation);
			}
			yield return new WaitForSeconds(2.0f);
		}
		started = false;
	}
	
	public void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,range);
	}
}
