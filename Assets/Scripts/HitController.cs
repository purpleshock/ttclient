using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour
{
	public Text text;
	public Sprite spHead;
	public Sprite spChest;
	public Sprite spBelly;
	public Sprite spLowerBody;


	private string currentSpriteName;

	void Start ()
	{
		currentSpriteName = gameObject.tag;
		Debug.Log(GameControl.Control.myNum);
	}

	void Update ()
	{
		
		/*
		if (Input.touchCount > 0) {
			Touch myTouch = Input.GetTouch (0);
			if (myTouch.phase == TouchPhase.Ended) {
				text.text = "Touch " + gameObject.tag;
				ChangeSprite ();
			}
		}

		
		*/
		/*
		if (GetComponent<Animator> ().GetBool ("head")) {
			GetComponent<Animator> ().SetBool ("head", false);
		}
		*/

		if (Input.GetMouseButtonDown (0)) {
			Vector2 origin = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
				                 Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast (origin, Vector2.zero, 0f);
			if (hit) {
				Debug.Log ("CLICKED " + hit.collider.name);

				if (hit.collider.name == "Head" ||
				    hit.collider.name == "Chest") {
					//hit.transform.parent.GetComponent<Animator> ().SetBool ("head", true);
					//Debug.Log (GetComponent<Animator> () == null);
					GetComponent<Animator> ().SetTrigger (hit.collider.name + "Trigger");
				}
			} else {
				Debug.Log ("CLICKED nothing");
			}
		} else {
			//
		}

	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + Vector3.forward);
	}

	void ChangeSprite ()
	{
		if (gameObject.tag != "Empty") {
			SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer> ();
			spr.sprite = RandomSprite ();
		}
	}

	Sprite RandomSprite ()
	{
		Sprite sprite = null;

		List<string> spriteNameList = new List<string> ();
		spriteNameList.Add ("Head");
		spriteNameList.Add ("Chest");
		spriteNameList.Add ("Belly");
		spriteNameList.Add ("LowerBody");
		spriteNameList.Remove (currentSpriteName);

		int spriteIndex = Random.Range (0, spriteNameList.Count);

		currentSpriteName = spriteNameList [spriteIndex];

		switch (currentSpriteName) {
		case "Head":
			sprite = spHead;
			break;
		case "Chest":
			sprite = spChest;
			break;
		case "Belly":
			sprite = spBelly;
			break;
		case "LowerBody":
			sprite = spLowerBody;
			break;
		}

		return sprite;
	}
}
