using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachin : MonoBehaviour
{
    public int Health;
    public int CurrentHealth;
    public bool Hurt;
    /// <summary>
    /// Change player Health regarding the damage value
    /// </summary>
    /// <param name="damage">damage recieve by the player</param>
    public void PlayerHealthDamage(int damage)
    {
        Health = damage > 0 ? Health - damage : Health;
        Hurt = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.Find("Player").GetComponent<PlayerController>().Health;
        //CurrentHealth = Health;
        Hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hurt)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Hurt");
            gameObject.layer = LayerMask.NameToLayer("PlayerInvincible");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            CurrentHealth = GameObject.Find("Player").GetComponent<PlayerController>().Health;
            Health = GameObject.Find("Player").GetComponent<PlayerController>().Health;
        }

        if(gameObject.layer == LayerMask.NameToLayer("PlayerInvincible"))
        {
            StartCoroutine(Wait());
        }
    }

    /// <summary>
    /// time when the player is invulnerable
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Hurt = false;
    }
}
