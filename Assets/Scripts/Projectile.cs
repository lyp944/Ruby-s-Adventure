using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public ParticleSystem _hitEffect;
	private Rigidbody2D _rigidbody2D;

	// Start is called before the first frame update
	void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (transform.position.magnitude > 1000f)
		{
			Destroy(gameObject);
		}
	}

	public void Launch(Vector2 direction, float force)
	{
		_rigidbody2D.AddForce(direction * force);
	}

	#region Physic

	private void OnCollisionEnter2D(Collision2D other)
	{
		EnemyController e = other.collider.GetComponent<EnemyController>();
		if (e != null)
		{
			e.Fix();
		}

		Instantiate(_hitEffect, other.GetContact(0).point, Quaternion.identity);
		Destroy(gameObject);
	}

	#endregion
}