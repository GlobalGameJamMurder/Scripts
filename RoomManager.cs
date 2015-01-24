using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

	public Room CurrentRoom;

	private static RoomManager instance = null;
	// Use this for initialization
	void Start () {
		if (instance == null) {
						instance = this;
				}

	}

	public static RoomManager Instance {
				get {
			if(instance == null) {
				instance = FindObjectOfType<RoomManager>();
			}
			return instance;
				}
		}

	// Update is called once per frame
	void Update () {
	
	}
}
