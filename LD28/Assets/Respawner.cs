using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

	public GameObject tank;
	
	public void Start(){
		StartCoroutine(SpawnAfterTime());
	}
	
	public IEnumerator SpawnAfterTime(){
		yield return new WaitForSeconds(30);
		Instantiate(tank, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
