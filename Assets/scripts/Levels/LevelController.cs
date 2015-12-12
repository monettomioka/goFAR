using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
    public GameObject player;
    public GameObject[] inOrderGoals;
    public GameObject[] farSymbols;
    public string[] messages;

    private string[] backgrounds;
    private int curBackground;
    private int goalIndex;
    private int farIndex;
    private bool optionsMenu;
	// Use this for initialization
	void Start () {
        goalIndex = 0;
        farIndex = 0;
        optionsMenu = false;

        messages = new string[3];
        messages[0] = "Focus And Plan Your Route By Clicking In The Correct Order!";
        messages[1] = "Action! Follow Your Route By Moving Miles With The Cursor!";
        messages[2] = "Reflect! How Did You Accomplish Your Action?";

        backgrounds = new string[3];
        backgrounds[0] = "/Backgrounds/Clouds";
        backgrounds[1] = "/Backgrounds/Space";
        curBackground = 0;

        player.GetComponent<Miles>().enabled = false; //disable Miles for the 'F' stage
        SpinAllSprites();
        Scale(farSymbols[farIndex].transform, 1.5f); //Enlarge the F
	}
	
    void Click(GameObject objClicked) {
        if (isFarOrReflectStage()) {
            StateChecker(objClicked);
        }
    }

    void Collide(GameObject objCollide) {
        if (!isFarOrReflectStage()) {
            StateChecker(objCollide);
        }
    }

    private void StateChecker(GameObject objToCheck) {
        if (objToCheck == inOrderGoals[goalIndex]) {
            inOrderGoals[goalIndex].GetComponentInChildren<ShineSpin>().isSpinning = false;
            MoveMiles();
            goalIndex++;
            if (goalIndex == inOrderGoals.Length) {
                goalIndex = 0;
                Scale(farSymbols[farIndex].transform, .66f);
                player.GetComponent<Miles>().enabled = !player.GetComponent<Miles>().enabled;
                farIndex++;
                if (farIndex == farSymbols.Length) {
                    Application.LoadLevel("MainMenu");
                } else {
                    SpinAllSprites();
                    Scale(farSymbols[farIndex].transform, 1.5f);
                }
            }
        } else {
            //handle what should be done if they keep clicking wrong here. Ergo "if 4th time, prompt with phrase "maybe try X"
        }
    }

    private void SpinAllSprites() {
        for (int i = 0; i < inOrderGoals.Length; i++) {
            inOrderGoals[i].GetComponentInChildren<ShineSpin>().isSpinning = true;
        }
    }

    private bool isFarOrReflectStage() {
        return !player.GetComponent<Miles>().enabled;
    }

    private void MoveMiles() {
        if (isFarOrReflectStage()) {
            player.transform.position = inOrderGoals[goalIndex].transform.position;
        }
    }
    private void Scale(Transform transform, float ratio) {
        transform.localScale = transform.localScale * ratio;
    }

    void OnGUI() {
        int width = 400;
        if (optionsMenu) {
            GUI.Box(new Rect((Screen.width - width) / 2, Screen.height / 4, width, 120), "");
            if (GUI.Button(new Rect((Screen.width - width) / 2 + 20, Screen.height / 4 + 20, 200, 40), "Change Background")) {
                curBackground = curBackground + 1 % backgrounds.Length;
                GameObject bg = GameObject.FindGameObjectWithTag("Background");
                SpriteRenderer bgSpriteRenderer = bg.GetComponent<SpriteRenderer>();
                //bgSpriteRenderer.sprite = 
            }
            if (GUI.Button(new Rect((Screen.width - width) / 2 + 20, Screen.height / 4 + 80, 200, 40), "Exit Level")) {
                Application.LoadLevel("MainMenu");
            }
        } else if (farIndex != farSymbols.Length) {
            GUI.Box(new Rect((Screen.width - width) / 2, Screen.height / 4, width, 30), messages[farIndex]);
        }
    }
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)) {
            optionsMenu = !optionsMenu;
        }
	}
}
