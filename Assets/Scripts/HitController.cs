using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

	public Text text;

	void Update(){
		if (Input.touchCount > 0) {
			Touch myTouch = Input.GetTouch (0);
			if (myTouch.phase == TouchPhase.Ended) {
				text.text = "Touch " + gameObject.tag;
			}
		}
	}
	
	void OnMouseDown(){
		text.text = "Click " + gameObject.tag;
	}
}
