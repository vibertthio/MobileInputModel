using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Hit;

public class ModelController : MonoBehaviour {
	public TapGesture singleTap;
	public TapGesture doubleTap;

	public float accelThreshold;

	private Animator animator;
	private int shakeCount = 0;

	// transform gesture
	public TransformGesture transformGesture;
	private Rigidbody rigidBody;
	private CapsuleCollider collider;


	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		Input.gyro.enabled = true;


		singleTap.Tapped += (object sender, System.EventArgs e) => {
			animator.SetTrigger("Tap");
		};
		doubleTap.Tapped += (object sender, System.EventArgs e) => {
			animator.SetTrigger ("DoubleTap");
		};

		// transform gesture
		rigidBody = this.GetComponent<Rigidbody> ();
		collider = this.GetComponent<CapsuleCollider> ();

		transformGesture.TransformStarted += (object sender, System.EventArgs e) => 
		{
			rigidBody.useGravity = false;
			rigidBody.velocity = Vector3.zero;
			collider.enabled = false;
		};

		transformGesture.Transformed += (object sender, System.EventArgs e) => 
		{
//			this.transform.position += transformGesture.DeltaPosition;
//			this.transform.Rotate(new Vector3(0,0,1),transformGesture.DeltaRotation);
			this.transform.localScale *= transformGesture.DeltaScale;
		};

		transformGesture.TransformCompleted += (object sender, System.EventArgs e) => 
		{
			rigidBody.useGravity = true;
			collider.enabled = true;
		};

	}

	// Update is called once per frame
	void Update () {
		
		if (Input.acceleration.magnitude > accelThreshold) {
			shakeCount++;
		}
		if (shakeCount > 10) {
			animator.SetTrigger ("Shake");
			shakeCount = 0;
		}
	}
}
