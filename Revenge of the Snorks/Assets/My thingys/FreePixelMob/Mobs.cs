using System.Collections;
using UnityEngine;

public class Mobs : MonoBehaviour
{
	static int AnimatorWalk = Animator.StringToHash("Walk");
	static int AnimatorAttack = Animator.StringToHash("Attack");
	Animator _animator;
	
	public int health = 20;
	public GameObject deathEffect;

	[SerializeField] private GameObject canvas;
	void Awake()
	{
		_animator = GetComponentInChildren<Animator>();
	}
	void Start()
	{
		StartCoroutine(Animate());
	}
	IEnumerator Animate()
	{
		yield return new WaitForSeconds(5f);
		while (true)
		{
			_animator.SetBool(AnimatorWalk, true);
			yield return new WaitForSeconds(1f);

			_animator.transform.localScale = new Vector3(-1, 1, 1);
			yield return new WaitForSeconds(1f);

			_animator.SetBool(AnimatorWalk, false);
			yield return new WaitForSeconds(1f);

			_animator.SetTrigger(AnimatorAttack);
			yield return new WaitForSeconds(1f);

			_animator.SetTrigger(AnimatorAttack);
			yield return new WaitForSeconds(1f);

			_animator.SetTrigger(AnimatorAttack);
			yield return new WaitForSeconds(5f);
		}
	}

	public void TakeDamage(int damage){
		health -= damage;

		if(health <= 0)
        {
			Die();
        }
    }

	public void Die()
    {
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
    }
	/*private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Debug.Log("2Colliding");
			canvas.SetActive(true);
		
		}
	}
	*/

}
