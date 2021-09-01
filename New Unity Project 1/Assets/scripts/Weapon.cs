﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : collidable 
{
	//damage strut
	public float pushForce = 2.0f;
	public int damagePoint = 1;

	//upgrade
	public int weaponLevel = 0;
	private SpriteRenderer spriteRenderer;

	//swing
	private Animator anim;
	private float cooldown = 0.5f;
	private float lastSwing;

	protected override void Start()
	{
		base.Start();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	protected override void Update()
	{
		base.Update();

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();
			}
		}
	}

	protected override void OnCollide(Collider2D coll)
	{
		if (coll.tag == "Fighter")
		{
			if (coll.name == "Player")
				return;

			// create a new damage object the nwell send it to the fighter we hit
			Damage dmg = new Damage
			{
				damageAmount = damagePoint,
				origin = transform.position,
				pushForce = pushForce
			};

			coll.SendMessage("ReceiveDamage", dmg);
		}
		
	}

	private void Swing()
	{
		anim.SetTrigger("Swing");
	}


}
