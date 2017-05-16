using UnityEngine;
using System.Collections;

public class WebCamManager : MonoBehaviour {

	public Material cameraMaterial;
	private WebCamTexture mCamera = null;

	// Use this for initialization
	void Start () {

		mCamera = new WebCamTexture (512,512,30);

		cameraMaterial.mainTexture = mCamera;
		mCamera.Play ();
	}

	// Update is called once per frame
	void Update () {

	}
}
