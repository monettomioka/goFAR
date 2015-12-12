using UnityEngine;
using System.Collections;

public class exitOnEscape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		If(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}
