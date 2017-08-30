using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLocator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindFlower();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FindFlower()
    {
        GameObject Flower1 = GameObject.Find("Flower");
        GameObject Flower2 = transform.Find("Flower").gameObject;

        Debug.Log(Flower1.name);
        Debug.Log(Flower2.name);
    }
}
