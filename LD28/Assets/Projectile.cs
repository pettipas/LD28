using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
	public Vector3 normailzedDir;
	
	public void SetDirection(Vector3 dir){
		normailzedDir = dir.normalized;
	}
	
	void Update () {
        transform.position += Time.deltaTime * speed * normailzedDir;
	}
}