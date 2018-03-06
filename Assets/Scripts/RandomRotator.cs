/* Stephen Randall
 * 03/06/18
 * This script is responsible for rotating the incoming hazards.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	private Rigidbody rb;
	public float tumble;
	void Start () {
		rb = GetComponent<Rigidbody> (); //Gets rigidbody, assigns to shorthand 'rb'
		rb.angularVelocity = Random.insideUnitSphere * tumble; //Random tumble
	}
}
