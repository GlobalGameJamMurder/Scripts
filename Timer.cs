using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private static Timer s_timerInstance;

	public static Timer Instance
	{
		get {return s_timerInstance;}
	}

	// Use this for initialization
	void Start () 
	{
		if(s_timerInstance == null)
		{
			s_timerInstance = this;
		}
	}

	public void StartTimer(int time)
	{
		StartCoroutine(CountTime(time));
	}

	IEnumerator CountTime(int time)
	{
		float endTime = Time.time + time;

		while(Time.time < endTime)
		{
			yield return null;
		}

		if(GameController.Instance.m_CurrentState == GameController.GAMESTATE.ACTIONSELECT)
		{
			GameController.Instance.SwitchState(GameController.GAMESTATE.ACTIONUSE);
		}
		else if(GameController.Instance.m_CurrentState == GameController.GAMESTATE.ACTIONUSE)
		{
			GameController.Instance.SwitchState(GameController.GAMESTATE.AITURN);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
