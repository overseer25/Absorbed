using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bin : MonoBehaviour {

	[HideInInspector]
	public bool satisfied;
	
	public Orb.Type expectedType;

	GameObject l;

	void Start(){
		l = transform.FindChild ("Light").gameObject;
	}
	void Update(){
		l.SetActive(satisfied);
	}

}