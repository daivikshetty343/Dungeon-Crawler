using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : collectible
{
	public Sprite emptyChest;
	public int cashAmount = 5;
	protected override void OnCollect()

	{
		if(!collected)
		{
			collected = true;
			GetComponent<SpriteRenderer>().sprite = emptyChest;
			GameManager.instance.ShowText("+$" + cashAmount,25, Color.yellow, transform.position,Vector3.up * 30,2.0f);
		}
	}

}
