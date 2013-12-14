using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public EnemyLauncher launcher;
	
	void Awake(){
		launcher = GetComponentInChildren<EnemyLauncher>();
	}
	
	void Start () {
		launcher.target = Control.instance.gameObject;
	}
	
}
