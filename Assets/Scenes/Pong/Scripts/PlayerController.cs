using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed = 2f;

	int player;

	KeyCode keyUp, keyDown;

	BoxCollider floorCollider, ceilingCollider, playerCollider;

	GameObject ball;
	BallController ballController;


	// Use this for initialization
	void Start () {
		if (tag == "Player") {
			player = 1;

			keyUp = KeyCode.W;
			keyDown = KeyCode.S;
		} else if (tag == "Player 2") {
			player = 2;

			keyUp = KeyCode.UpArrow;
			keyDown = KeyCode.DownArrow;
		}
		
		ceilingCollider = GameObject.FindWithTag ("Ceiling").GetComponent<BoxCollider> ();
		floorCollider = GameObject.FindWithTag ("Floor").GetComponent<BoxCollider> ();

		playerCollider = GetComponent<BoxCollider> ();

		ball = GameObject.FindWithTag ("Ball");
		ballController = ball.GetComponent<BallController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		bool p2Override = false;
		if (Input.touchCount > 0)
		{
			foreach (Touch t in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay(t.position);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit))
				{
					if((hit.point.x < 0 && player == 1))
					{
						transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
					}
					if((hit.point.x > 0 && player == 2))
					{
						transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
						p2Override = true;
					}
				}
			}
		}

		if(!p2Override)
		{
			if (GameType.GAMETYPE == GameType.PLAYER || (GameType.GAMETYPE == GameType.COMPUTER && player == 1))
			{
				if (Input.GetKey (keyUp))
				{
					if (!playerCollider.bounds.Intersects (ceilingCollider.bounds))
						transform.position += transform.up * speed;
				}
				if (Input.GetKey (keyDown))
					if (!playerCollider.bounds.Intersects (floorCollider.bounds))
						transform.position += transform.up * -speed;

			} else {
				//AI goes here

				float v = Mathf.Clamp ((ball.transform.position - transform.position).y, -speed, speed);

				float pos;

			
				if ((v < 0 && !playerCollider.bounds.Intersects (floorCollider.bounds)) || (v > 0 && !playerCollider.bounds.Intersects (ceilingCollider.bounds))) {
				
					if (((ball.transform.position.x > 0 || ballController.h > 0) && player == 1) || ((ball.transform.position.x < 0 || ballController.h < 0) && player == 2)) {
						//transform.position += transform.up * v
						transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, 0, transform.position.z), speed / 5);
					} else {
						//transform.position += transform.up * v;
						pos = Mathf.Clamp ((ball.transform.position.y - transform.position.y) * .3f, -speed, speed);

						transform.position += transform.up * pos;
					}
				}
			}
		}
	}
}
