using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void OnPlayHumanPressed()
	{
		StartGame (GameType.PLAYER);
	}

	public void onPlayComputerPressed()
	{
		StartGame (GameType.COMPUTER);
	}

	public void StartGame(int gametype)
	{
		GameType.GAMETYPE = gametype;
		Application.LoadLevel ("Pong");
	}
}
