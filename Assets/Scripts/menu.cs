using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour {
	AudioSource ass;
	// Use this for initialization
	void Start () {
		ass = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			ass.Play ();
			//	Debug.Log ("Clicked");
			Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if (hitInfo) {
				Debug.Log (hitInfo.transform.gameObject.name);
				makeTrasac(hitInfo.transform.gameObject.name);
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
			}
		}
	}
	void makeTrasac(string ob)
	{
		if (ob == "sp") 
		{
			SceneManager.LoadScene (1);
		}
		if (ob == "ex") {
			Debug.Log ("working");
			Application.Quit ();
		}
	}
}
