using UnityEngine;
using System.Collections;

public class BoundingBox : MonoBehaviour {
    private Vector3 milesInitState;

    void Start() {
        milesInitState = GameObject.FindGameObjectWithTag("Miles").transform.position;
    }

	void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Miles") {
            col.transform.position = milesInitState;
        }
    }
}
