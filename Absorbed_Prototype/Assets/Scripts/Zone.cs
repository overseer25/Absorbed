using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zone : MonoBehaviour {

	BoxCollider b;
	Bin bin;

	List<GameObject> objects = new List<GameObject>();
	Queue<GameObject> removeObjects = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
		b = GetComponent<BoxCollider> ();
		bin = transform.parent.GetComponent<Bin> ();
	}

	// Update is called once per frame
	void Update () {
		bool temp;

		foreach (GameObject g in objects) {
			if (!b.bounds.Intersects (g.GetComponent<Collider> ().bounds)) {
				removeObjects.Enqueue (g);
			}
		}
		while (removeObjects.Count > 0)
			objects.Remove(removeObjects.Dequeue ());

		temp = false;
		foreach (GameObject g in objects) {
			if (g.GetComponent<Orb> ().type == bin.expectedType) {
				temp = true;
			}
		}

		bin.satisfied = temp;
	}
	void OnTriggerEnter(Collider other){
		Orb b = other.gameObject.GetComponent<Orb> ();
		if (b == null)
			return;
		objects.Add (b.gameObject);
	}

	public List<GameObject> GetContainedObjects(){
		return objects;
	}
}
