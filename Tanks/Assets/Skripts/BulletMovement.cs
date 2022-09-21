using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	//Assignables
	public GameObject explosion;
	public LayerMask whatIsEnemies;


	//Stats
	[Range(0f,1f)]
	public float bounciness;

	//Damage
	public int explosionDamage;

	//Lifetime
	public int maxCollisions;
	public bool explodeOnTouch = true;

	int collisions;
	PhysicMaterial physics_mat;

	private void Start()
	{
		Setup();
	}

	private void Update()
	{
		//When to explode 
		if (collisions > maxCollisions) Explode();
	}

	private void Explode()
	{
		//Instantiate explosion
		if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

		//Add a little delay, just to make sure everything works fine
		Invoke("Delay",0.04f);
	}

	private void Delay()
	{
		Destroy(gameObject);
	}


	private void OnCollisionEnter(Collision collision)
	{
		//Don´t count collisions with other bullets
		//if (collision.collider.CompareTag("Bullet")) return;

		//Count up collisions
		collisions++;

		if(collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
	}


	private void Setup()
	{
		//Create a new Physic material
		physics_mat = new PhysicMaterial();
		physics_mat.bounciness = bounciness;
		physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
		physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
		//Assign material to collider
		GetComponent<SphereCollider>().material = physics_mat;

	}

}
