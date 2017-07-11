using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

	public Text text;
	
	void OnMouseDown(){
		text.text = "Click " + gameObject.tag;
	}
}
