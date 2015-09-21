using UnityEngine;
using System.Collections;

public class GameType : MonoBehaviour {
	
	public const int PLAYER=1;
	public const int COMPUTER=2;
	public const int CVC=3;

	public static int GAMETYPE = CVC;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
}
