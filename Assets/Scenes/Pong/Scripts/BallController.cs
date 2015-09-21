using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	public float h;

	public float v; //Vertical velocity on ball.
	public float vIntensity; //Multiplier for v. The actual velocity applied to the ball is equal to (v * vIntensity).
	
	public float hVelocityIncrement;
	public float vVelocityIncrement;

	GameObject p1, p2;

	BoxCollider p1Collider, p2Collider, ballCollider;

	BoxCollider ceilingCollider, floorCollider;

	// Use this for initialization
	void Start () {

		h = 1.0f;

		if(GameType.GAMETYPE != GameType.PLAYER)
			v = Random.Range (-5, 5);

		vIntensity = .15f;

		hVelocityIncrement = .15f;
		vVelocityIncrement = .01f;

		p1 = GameObject.FindWithTag ("Player");
		p2 = GameObject.FindWithTag ("Player 2");

		p1Collider = p1.GetComponent<BoxCollider> ();
		p2Collider = p2.GetComponent<BoxCollider> ();

		ballCollider = GetComponent<BoxCollider> ();

		ceilingCollider = GameObject.FindWithTag ("Ceiling").GetComponent<BoxCollider> ();
		floorCollider = GameObject.FindWithTag ("Floor").GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (ballCollider.bounds.Intersects (p1Collider.bounds)) {
			h = -(h - hVelocityIncrement);
			vIntensity += vVelocityIncrement;
			v = (transform.position - p1.transform.position).y;
		} else if (ballCollider.bounds.Intersects (p2Collider.bounds)) {
			h = -(h + hVelocityIncrement);
			vIntensity += vVelocityIncrement;
			v = (transform.position - p2.transform.position).y;
		}

		if (ballCollider.bounds.Intersects (ceilingCollider.bounds) || ballCollider.bounds.Intersects (floorCollider.bounds))
			v = -v;

		transform.position += transform.right * h;
		transform.position += transform.up * (v * vIntensity);
	}
}
