using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	
	void Start () {
		guiText.text = "Congradulations. Your plant will be able to\nsurvive on its own. Thank you for playing\nthrough my submission.\n\n\nA team player is you.";

	}
	
	void Update(){
		if(Input.anyKey){
			Application.LoadLevel("start");
		}
	}
	
}
