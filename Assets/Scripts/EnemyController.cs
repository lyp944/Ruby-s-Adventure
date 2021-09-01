using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public ParticleSystem smokeEffect;
    public bool vertical;
    public float speed = 2f;
    public float timeTurn = 4f;

    private AudioSource audioSource;
    private Rigidbody2D rigidbody;
    private float turnTimer;
    private float speedDir = 1;

    private bool broken = true;

    private Animator animator;
    
    void Start()
    {
        turnTimer = timeTurn;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!broken)
        {
            return;
        }
        
        turnTimer -= Time.deltaTime;
        if (turnTimer < 0)
        {
            turnTimer = timeTurn;
            speedDir *= -1;
        }
    }

    private void FixedUpdate()
    {

        if (!broken)
        {
            return;
        }
        
        Vector2 pos = transform.position;
        if (vertical)
        {
            pos.y = pos.y + speedDir * speed * Time.deltaTime;
            animator.SetFloat("MoveX",0);
            animator.SetFloat("MoveY",speedDir);

        }
        else
        {
            pos.x = pos.x + speedDir * speed * Time.deltaTime;
            animator.SetFloat("MoveX",speedDir);
            animator.SetFloat("MoveY",0);
        }
        rigidbody.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        animator.SetTrigger("Fix");
        smokeEffect.Stop();
        rigidbody.simulated = false;
        audioSource.Stop();
    }
}
