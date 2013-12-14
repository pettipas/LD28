using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
	public GameObject explosion;
	void Start(){
		StartCoroutine(WaitAndDestroy());
	}
	
	void Update () {
		Vector3 previous = transform.position;
        transform.position += Time.deltaTime * speed * transform.forward;
		Vector3 current = transform.position;
		RaycastHit hit;
		if (Physics.Raycast (previous, transform.forward, out hit, Vector3.Distance(previous,current))) {
			Debug.Log (hit.transform.name);
			Instantiate(explosion,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
	
	public IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(3.0f);
		if(gameObject != null){
			Destroy(gameObject);
		}
	}
}