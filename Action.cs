using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

	public ActionController.ACTIONS m_ActionType;
	public int m_ActionCost;

	// Use this for initialization
	void Start () {
	
	}

	public void SetAction(ActionController.ACTIONS action)
	{
		m_ActionType = action;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
