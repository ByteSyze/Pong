using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	int p1Score = 0;
	int p2Score = 0;

	BoxCollider p1Goal, p2Goal, ballCollider;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (this);

		p1Goal = GameObject.FindWithTag ("Goal 1").GetComponent<BoxCollider> ();
		p2Goal = GameObject.FindWithTag ("Goal 2").GetComponent<BoxCollider> ();

		ballCollider = GameObject.FindWithTag ("Ball").GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ballCollider.bounds.Intersects (p1Goal.bounds)) {
			p2Score += 1;
			Application.LoadLevel("Pong");
			print("P2 score:");
			print (p2Score);
		} else if(ballCollider.bounds.Intersects(p2Goal.bounds)){
			p1Score += 1;
			Application.LoadLevel("Pong");
			print("P1 score:");
			print (p1Score);
		}
	}
}
