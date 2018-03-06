/* Stephen Randall
 * 03/06/18
 * This script is responsible for destroying item that have gone out of our gae view and are no longer relevant.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) //When it triggers with boundary
	{
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);
	}




}
