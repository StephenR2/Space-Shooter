/* Stephen Randall
 * 03/06/18
 * This script is responsible for all things that the player controls, shots, firerate, cooldown, score,etc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Boundary
{
	public float xMin, xMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour 
{
	// Values and Variables
	private Rigidbody rb;
	private AudioSource ac;
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	public int score;

	void Start () //What happens upon start, get rgidbody and audiosource assign to shorthand, 'rb' and 'ac'
	{
		rb = GetComponent<Rigidbody> ();
		ac = GetComponent<AudioSource> ();

	}
	void Update () //Updating fire, defines when its ok to fire again, instantiates shot.
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			ac.Play ();
		}


	}
	void FixedUpdate () //Gives player its speed, and boundaries of the game view.
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = (movement * speed);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)

		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
