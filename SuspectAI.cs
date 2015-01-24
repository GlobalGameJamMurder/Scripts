using UnityEngine;
using System.Collections;

public class SuspectAI : MonoBehaviour {

	Room m_CurrentRoom;
	int m_Moves;

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
			m_CurrentRoom = m_CurrentRoom.GetRandomRoom();
			Debug.Log ("Moved to " + m_CurrentRoom.name);
			++count;

			if(m_CurrentRoom == GameController.Instance.PlayerRoom())
			{

			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
