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

	public void StartTimer(int time, System.Action onComplete, System.Func<float, GameController.GAMESTATE, bool> timeRemaining)
	{
		StartCoroutine(CountTime(time, onComplete, timeRemaining));
	}

	IEnumerator CountTime(int time, System.Action onComplete, System.Func<float, GameController.GAMESTATE, bool> timeRemaining )
	{
		float endTime = Time.time + time;
		GameController.GAMESTATE state = GameController.Instance.m_CurrentState;

		while(Time.time < endTime)
		{
			if(!timeRemaining(endTime - Time.time, state))
				yield break;
			yield return null;
		}

		onComplete ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
