using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("isFase2", true);
		}

		if (health <= 0)
		{
			StartCoroutine(DieAndLoadScene());
		}
	}

	private IEnumerator DieAndLoadScene()
	{
		
		Die();
		yield return new WaitForSeconds(0.9f);
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	void Die()
	{
		GetComponent<Animator>().SetBool("Die", true);
		GameObject bossSlider = GameObject.Find("Slider");
		bossSlider.SetActive(false);
		Destroy(gameObject, 1f);
	}
}
