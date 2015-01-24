using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController s_Instance;

	public GAMESTATE m_CurrentState;

	public enum GAMESTATE
	{
		ACTIONSELECT,
		ACTIONUSE,
		AITURN,
		WAITING
	}

	public static GameController Instance
	{
		get {return s_Instance;}
	}

	// Use this for initialization
	void Start () {
		if(s_Instance == null)
		{
			s_Instance = this;
		}
	}

	public void SwitchState(GAMESTATE nextState)
	{
		m_CurrentState = nextState;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void FireDialogue(string text)
	{
		//Call the UI function.
	}
}
