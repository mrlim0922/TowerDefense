using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    float y = 130;



    void Update () {

        y  = y + 0.1f;
    
        Vector3 rotation = new Vector3(0f, transform.rotation.y + y, 0f);
        transform.rotation = Quaternion.Euler(rotation);
	}
}
