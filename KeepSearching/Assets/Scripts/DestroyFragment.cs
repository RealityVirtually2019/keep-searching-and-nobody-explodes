using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyFragment : MonoBehaviour {

    public float minY = -0.5f;

    // Use this for initialization
    void Start ()
    {

    }

	// Update is called once per frame
	void Update () {


        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
