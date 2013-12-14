using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public IEnumerator Start(){
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
}
