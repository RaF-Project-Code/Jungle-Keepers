using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeruang : MonoBehaviour
{
	public Transform player;
	public bool canLookAtPlayer = true;
	public bool isFlipped = false;


	public void LookAtPlayer()
	{
		if (!canLookAtPlayer || player == null) // Cek flag dan player
			return;

		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
