using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStr;
    private LogicManagerScript logicScript;
    public bool birdIsAlive = true;

    public int maxHealth = 100;
    public int health = 100;
    public float immuneDuration = 1.5f;
    public float immuneTimer = 0;
    public bool isImmmune = false;

    public Image healthBar;

    public CircleCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicManagerScript>();
        playerCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdIsAlive) return;
        Debug.Log(rb.velocity);
        healthBar.fillAmount = (float)health / (float)maxHealth;

        if (isImmmune)
        {
            if (immuneTimer < immuneDuration)
            {
                immuneTimer += Time.deltaTime;
            } else
            {
                isImmmune = false;
                playerCollider.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * flapStr;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(20);

        if (health <= 0)
        {
            logicScript.gameOver();
            birdIsAlive = false;
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        isImmmune = true;
        immuneTimer = 0;
        playerCollider.enabled = false;
    }
}
