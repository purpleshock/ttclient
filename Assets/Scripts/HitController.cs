using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour
{
	public Text text;
	public Sprite spHead;
	public Sprite spBreast;
	public Sprite spBelly;
	public Sprite spLowerBody;

	void Update ()
	{
		if (Input.touchCount > 0) {
			Touch myTouch = Input.GetTouch (0);
			if (myTouch.phase == TouchPhase.Ended) {
				text.text = "Touch " + gameObject.tag;
				ChangeSprite ();
			}
		}
	}

	void OnMouseDown ()
	{
		text.text = "Click " + gameObject.tag;
		ChangeSprite ();
	}

	void ChangeSprite ()
	{
		if (gameObject.tag != "Empty") {
			SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer> ();
			spr.sprite = spHead;
		}
	}
}
