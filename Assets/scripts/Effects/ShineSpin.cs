using UnityEngine;
using System.Collections;

public class ShineSpin : MonoBehaviour {
    public bool isSpinning;

    private bool waitToSwitchSpin;

    private float spinSpeed;
	// Use this for initialization
	void Start () {
        spinSpeed = 80f;
        waitToSwitchSpin = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (isSpinning)
        {
            if (!waitToSwitchSpin)
            {
                waitToSwitchSpin = true;
                StartCoroutine(SwitchSpin());
            }
            transform.Rotate(new Vector3(0, 0, spinSpeed * Time.deltaTime));
        }
	}

    private IEnumerator SwitchSpin()
    {
        yield return new WaitForSeconds(2f);
        spinSpeed = -spinSpeed;
        waitToSwitchSpin = false;
    }
}
