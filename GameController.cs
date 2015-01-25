using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int m_ChooseActionCountDown;
	public int m_UseActionCountDown;
	//public int m_UseItemCountDown;

	public static GameController s_Instance;

	public SuspectAI m_AIController;
	private StateManager m_StateManager;

	public GAMESTATE m_CurrentState;

	public enum GAMESTATE
	{
		ACTIONSELECT,
		ACTIONUSE,
		AITURN,
		WAITING,
		NONE
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

		m_StateManager = GetComponent<StateManager>();
		GetComponent<UIManager> ().DisplayMessengerText ("Incoming Info,\nAre You Ready?", StartFlash );
	}

	public void LaunchWaiting()
	{
		m_StateManager.SetState ((int)GAMESTATE.WAITING);
		GetComponent<UIManager> ().DisplayMessengerText ("Incoming Info,\nAre You Ready?", StartFlash );
	}


	public void LaunchGameState()
	{
		if (m_CurrentState != GAMESTATE.ACTIONUSE)
		{
			m_StateManager.SetState((int)GAMESTATE.ACTIONUSE);
			Timer.Instance.StartTimer (m_UseActionCountDown, LaunchAIState, SetUITimer);	
		}

	}

	public void LaunchAIState()
	{

		m_StateManager.SetState ((int)GAMESTATE.AITURN);
		GetComponent<ActionController> ().ResetActions ();
		m_AIController.TakeTurn ();
		
	}

	public bool SetUITimer(float timeRemaining, GAMESTATE state)
	{
		GetComponent<UIManager> ().UpdateTimer ((int)timeRemaining);
		if(m_CurrentState != state)
			return false;
		return true;
	}

	public void StartFlash()
	{
		StartCoroutine (Flash ());
	}
	
	private IEnumerator Flash()
	{
		Image blackScreen = m_StateManager.blackScreen;
		blackScreen.gameObject.SetActive (true);
		Color color = blackScreen.color;
		float endtime = Time.time + 0.1f;
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.1f;
			color.a = 1-s;
			blackScreen.color = color;
			yield return null;
		}
		
		m_StateManager.m_GameScreen.SetActive (true);
		
		endtime = Time.time + 0.1f;
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.1f;
			color.a = s;
			blackScreen.color = color;
			yield return null;
		}
		
		yield return new WaitForSeconds (1f);
		
		endtime = Time.time + 0.2f;
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.2f;
			color.a = 1-s;
			blackScreen.color = color;
			yield return null;
		}
		
		m_StateManager.m_GameScreen.SetActive (false);
		m_StateManager.m_AbilitySelectScreen.SetActive (true);
		
		while (Time.time < endtime)
		{
			float s  = (endtime - Time.time)/0.5f;
			color.a = s;
			blackScreen.color = color;
			yield return null;
		}
		
		blackScreen.gameObject.SetActive (false);
		GetComponent<UIManager> ().ShowTimer (true);
		Timer.Instance.StartTimer (m_ChooseActionCountDown, LaunchGameState, SetUITimer);
	}
	
	public void FireDialogue(string text)
	{
		GetComponent<UIManager> ().DisplayMessengerText (text);
	}
}
