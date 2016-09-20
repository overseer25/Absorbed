using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 6.0f;
	public float jumpSpeed = 4f;
	float gravity = 9.8f;
	float vSpeed = 0;
	private RaycastHit hit;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0f;

	public Orb grabbedOrb;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
		Vector3 vel = (transform.forward * v + transform.right * h) * speed;

		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		if (cc.isGrounded) {
			vSpeed = 0;
			// We are grounded, so recalculate
			// move direction directly from axes

			if (Input.GetButton ("Jump")) {
				vSpeed = jumpSpeed;
			}
		}
		vSpeed -= gravity * Time.deltaTime;
		vel.y = vSpeed;


		cc.Move(vel * Time.deltaTime);




		if (grabbedOrb == null) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
			if (Physics.Raycast (ray, out hit, 1.5f)) {
				GameObject go = hit.collider.gameObject;
				if (go.GetComponent<Orb> () != null) {
					go.GetComponent<Orb> ().Hover ();

					if (Input.GetMouseButtonDown (0)) {
						grabbedOrb = go.GetComponent<Orb> ();
						grabbedOrb.grabbed = true;
						foreach (Collider c in go.GetComponents<Collider>())
							c.enabled = false;
						grabbedOrb.GetComponent<Rigidbody>().useGravity = false;
						grabbedOrb.GetComponent<Rigidbody>().Sleep ();
					}
				}
			}
		} else {
			grabbedOrb.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * .6f);
			grabbedOrb.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);

			if (Input.GetMouseButtonDown (0)) {
				Vector3 pos = Camera.main.transform.position + (Camera.main.transform.forward * .35f);
				Orb b = grabbedOrb.GetComponent<Orb>();
				b.grabbed = false;
				grabbedOrb.transform.position = pos;
				b.GetComponent<Rigidbody>().WakeUp();
				b.GetComponent<Rigidbody>().useGravity = true;
				b.GetComponent<Rigidbody>().isKinematic = false;
				b.GetComponent<Rigidbody>().velocity = cc.velocity;
				foreach(Collider c in grabbedOrb.GetComponents<Collider>())
					c.enabled = true;
				grabbedOrb = null;
			}
			else if(Input.GetButtonDown("Throw")){
				Vector3 pos = Camera.main.transform.position + (Camera.main.transform.forward * .35f);
				Orb b = grabbedOrb.GetComponent<Orb>();
				grabbedOrb.transform.position = pos;
				b.GetComponent<Rigidbody>().WakeUp();
				b.GetComponent<Rigidbody>().useGravity = true;
				b.GetComponent<Rigidbody>().isKinematic = false;
				foreach(Collider c in grabbedOrb.GetComponents<Collider>())
					c.enabled = true;
				b.GetComponent<Rigidbody> ().AddForce (transform.forward * 500);
				grabbedOrb = null;
			}
		}
	}
}
