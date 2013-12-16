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
			if(target == null){
				yield break;
			}
			yield return new WaitForSeconds(1.5f);
			if(target == null){
				yield break;
			}
			if(Vector3.Distance(target.transform.position,transform.position) < range){
				Instantiate(projectile,transform.position,transform.rotation);
			}
		}
		started = false;
	}
	
	public void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position,range);
	}
}
