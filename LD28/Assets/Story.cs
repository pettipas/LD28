using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	
	public GUIText text;
	
	public void Start(){
		text.text = "You must terraform the earth \nusing the last plant from \nyour home planet. Feed the plant \nwith humans until it reaches \nmaturity";
	}
	
	public void Update(){
		if(Input.anyKey){
			Application.LoadLevel("main");
		}
	}
}
