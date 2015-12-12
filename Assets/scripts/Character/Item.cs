using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    GameObject permanentParent;

    void Start() {
        permanentParent = transform.parent.gameObject;
    }
    void OnMouseDown() {
        CommunicateToLevel("Click");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Miles") {
            Debug.Log("lel");
            CommunicateToLevel("Collide");
        }
    }

    private void CommunicateToLevel(string method) {
        GameObject.FindGameObjectWithTag("LevelController").SendMessage(method, permanentParent);
    }
}
