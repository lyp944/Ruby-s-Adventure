using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
	public AudioClip collectedClip;
	private void OnTriggerEnter2D(Collider2D other)
	{
		RubyController controller = other.GetComponent<RubyController>();
		if (controller)
		{
			if (controller.health < controller.maxHealth)
			{
				controller.PlaySound(collectedClip);
				controller.ChangeHealth(1);
				Destroy(gameObject);
			}

		}
	}
}
