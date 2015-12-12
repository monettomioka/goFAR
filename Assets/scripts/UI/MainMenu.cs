using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(string level) {
		Application.LoadLevel ("Level" + level);
	}

    public void DisplayLevels(Button[] buttonArr)
    {
        foreach(Button button in buttonArr)
        {
            Color temp = button.image.color;
            temp.a = 0f;
            button.image.color = temp;
        }
    }
}
