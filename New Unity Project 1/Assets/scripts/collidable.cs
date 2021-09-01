using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class collidable : MonoBehaviour
{

	public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
	private Collider2D[] hits = new Collider2D[10];

	protected virtual void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	protected virtual void Update()
	{
		//collision work

		boxCollider.OverlapCollider(filter, hits);
		for (int i = 0; i < hits.Length; i++)
		{
			if (hits[i] == null)
				continue;

			OnCollide(hits[i]);

			//the arrat is not cleaned up, so we gave to do it
			hits[i] = null;
		}
	}
		protected virtual void OnCollide(Collider2D coll)
	{
		Debug.Log(coll.name);
	}
}
