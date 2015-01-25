using UnityEngine;
using System.Collections;

public class SuspectAI : MonoBehaviour {

	public Room m_CurrentRoom;
	private Room m_LastRoom;
	public int m_Moves = 1;

	public void SetMoves(int moves)
	{
		m_Moves = moves;
	}

	// Use this for initialization
	public void TakeTurn () 
	{
		StartCoroutine (Think ());	
	}

	IEnumerator Think()
	{
		int count = 0;
		while (count < m_Moves)
		{
			yield return new WaitForSeconds (1); //To make it more suspens-y
			for (int i = 0 ; i < 10 ; ++i)
			{
				Room newRoom = m_CurrentRoom.GetRandomRoom();

				if(newRoom != m_LastRoom )
				{

					m_LastRoom = m_CurrentRoom;
					m_CurrentRoom  = newRoom;
					break;
				}
				if(i == 9)
				{
					m_LastRoom = null;
				}
			}
			Debug.Log ("Moved to " + m_CurrentRoom.name);
			transform.position = m_CurrentRoom.transform.position;
			++count;

			if(m_CurrentRoom == Player.Instance.m_CurrentRoom)
			{
				GameController.Instance.m_StateManager.StartFade(GameOver, true);

			}
		}

		yield return new WaitForSeconds (2);
		GameController.Instance.LaunchWaiting();


	}

	public void GameOver()
	{

		GameController.Instance.FireDialogueCallBack("GAME OVER",BackToMainMenu);
		GameController.Instance.m_StateManager.m_GameScreen.SetActive(false);
		GameController.Instance.m_StateManager.m_AbilitySelectScreen.SetActive(false);
		//StartCoroutine (Flash ());
	}

	public void BackToMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
	// Update is called once per frame
	void Start () {
		transform.position = m_CurrentRoom.transform.position;
		m_LastRoom = m_CurrentRoom;
	}
}
