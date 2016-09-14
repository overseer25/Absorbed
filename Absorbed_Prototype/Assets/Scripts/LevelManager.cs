using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	List<Bin> bins = new List<Bin>();

	// Use this for initialization
	void Start () {
		//Debug.Log (GameObject.Find ("Bins").transform == null);
		foreach (Transform child in GameObject.Find("Bins").transform) {
			bins.Add(child.GetComponent<Bin>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool temp = true;
		foreach (Bin bin in bins)
			if (!bin.satisfied)
				temp = false;

		// Open door, level complete
		if (temp) {
			Debug.Log ("Level Complete - open door");
		}
	}
}
