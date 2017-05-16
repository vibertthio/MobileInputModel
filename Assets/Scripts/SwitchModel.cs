using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class SwitchModel : MonoBehaviour {
	public FlickGesture flick;
	public List<GameObject> models;

	// Use this for initialization
	void Start () {
		flick.Flicked += (object sender, System.EventArgs e) => {
			Debug.Log("flick!");
			if (models[0].activeSelf) {
				models[0].SetActive(false);
				models[1].SetActive(true);
			} else {
				models[0].SetActive(true);
				models[1].SetActive(false);
			}
		};
	}

	// Update is called once per frame
	void Update () {
		
	}
}
