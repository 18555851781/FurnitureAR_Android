using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_RingRotate : MonoBehaviour {

	void Update ()
    {
        if (this.gameObject.activeSelf == true)
        {
            transform.localEulerAngles += new Vector3(0, 1, 0);
        }
	}
}
