/* Stephen Randall
 * 03/06/18
 * This script is responsible for all things that make sure the game runs, keeping score, if statements, determining when score should be updated, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {
	// Values and Variables
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoretext;
	private int score;
	public Text restartText;
	public Text gameOverText;
	private bool gameOver;
	private bool restart;

	void Start(){ //What happens wen the game starts, resets everything, starts first wave.
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (Spawnwaves ());
	}
	void Update(){
		if (restart) { //If its restarting detect key R and reload already loaded level, thus restarting the game.
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
				
		}

	}
	IEnumerator Spawnwaves (){
		yield return new WaitForSeconds (startWait); //Amount of time to wait inbetween each wave.
		while (true)
		{
			for (int i = 0 ; i <hazardCount; i++) { //Spawns wave, random positions withing game view, Instantiates the hazard on screen.
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) { //Wait for objects to destroy, ask for R key press, if true set restart= true.
				restartText.text = "'R' to restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue) //Update score  value
	{
		score += newScoreValue;
		UpdateScore ();

	}
	void UpdateScore () //Update score text
	{
		scoretext.text = "Score: " + score;


	}
	public void GameOver (){ //if Game over true, print Game over, set to true.
		gameOverText.text = "Game over!";
		gameOver = true;
			

	}
}
