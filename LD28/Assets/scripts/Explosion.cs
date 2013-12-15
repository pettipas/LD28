using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float t;
    public AudioSource source;
	public IEnumerator Start(){
        source.Play();
        yield return new WaitForSeconds(t);
		Destroy(gameObject);
	}
}
