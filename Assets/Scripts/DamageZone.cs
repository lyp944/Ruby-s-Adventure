using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        if (controller)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(-1);
            }

        }
    }
}