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
	}

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
