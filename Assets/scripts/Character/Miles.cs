using UnityEngine;
using System.Collections;

public class Miles : MonoBehaviour {

	private Vector3 target;
    private bool isOnLadder;
    private Vector3 keyPosition;
    private Transform keyParent;

	void Start () {
		target = transform.position;
        isOnLadder = false;
	}
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Mathf.Abs(target.x - transform.position.x) < 2.5f) {
                if (isOnLadder && Mathf.Abs(target.y - transform.position.y) < 1.5f) {
                    target.Set(target.x, target.y, transform.position.z);
                } else {
                    target.Set(target.x, transform.position.y, transform.position.z);
                }
                transform.position = target;
            }
		} else if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel ("MainMenu");
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Key") {
            Debug.Log("parent");
            keyParent = col.transform.parent;
            keyPosition = col.transform.position;
            col.transform.parent = this.transform;
            col.transform.position = this.transform.position;
            col.transform.Translate(new Vector3(0f, 5f));
        }
        if (col.tag == "Door") {
            Transform keyTransform = this.transform.GetChild(0);
            keyTransform.parent = keyParent;
            keyTransform.position = keyPosition;
        }
        if (col.tag == "Ladder") {
            isOnLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Ladder") {
            isOnLadder = false;
        }
    }
}
