/* Stephen Randall
 * 03/06/18
 * This script is responsible for destroying player when coming into contact with hazards and hazards when they come into contact with a shot.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion; 
	public GameObject playerexplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
			if(gameControllerObject != null)
			{
				gameController = gameControllerObject.GetComponent <GameController> ();
			}
			if (gameControllerObject == null) 
			{
				Debug.Log("Cannot find 'GameController' script.");
			}

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation); //Instantiates explosion
		if (other.tag == "Player") { //If player comes into contact with hazard, Instantiate playerexplosion and end game.
			Debug.Log ("Test");
			Instantiate (playerexplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue); //Update score value
		Destroy(other.gameObject); //Destroys remaining game objects
		Destroy (gameObject);
	}
}
