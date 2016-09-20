using UnityEngine;
using System.Collections;

public class CatchZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Orb b = other.gameObject.GetComponent<Orb> ();
		if (b == null)
			return;
		b.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		b.gameObject.transform.position = transform.position;
	}
}
