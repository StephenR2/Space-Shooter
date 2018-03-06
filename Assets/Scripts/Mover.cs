/* Stephen Randall
 * 03/06/18
 * This script is responsible for movement of the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	void Start ()
	{

		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;

	}





}
