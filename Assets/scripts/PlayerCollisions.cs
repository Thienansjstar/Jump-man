using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;
public class PlayerCollisions : MonoBehaviour
{

    // public AudioSource playerDamage;


    public int health = 3;

    Rigidbody2D rb;
    public GameObject health3;
    public GameObject health1;
    public GameObject health2;
    public GameObject s;


    public GameObject currentGameObeject;
    public float alpha = 0.5f;

    public GameObject currentGameObject1;
    public float alpha1 = .05f;

    Vector2 knockback;
    bool invincible = false;
    public int invincibleTime;

    //audio

    public AudioSource playerDamage;

    public AudioSource waterSplash;
   

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = new Vector2(20f, 5f);
        currentGameObeject = gameObject;
        playerDamage.GetComponent<AudioSource>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.transform.tag == "Enemy")
            {

                health -= 1;
                // rb.AddForce(knockback * 5);
                // transform.position = new Vector2(Random.Range(0, 21), 6);
                StartCoroutine(nodamage());
                playerDamage.Play();


            }
        }

        if (collision.transform.tag == "Water")
        {
            health = 0;
            waterSplash.Play();
        }

    }


    private void Update()
    {
        Health();
    }
    private void EndGame()
    {
        GameManager.gameOver = true;
        Debug.Log("died");
        gameObject.SetActive(false);
        Destroy(gameObject);
        s.SetActive(false);


    }

    IEnumerator nodamage()
    {
        invincible = true;
        ChangeAlpha(currentGameObeject.GetComponent<Renderer>().material, alpha);
        yield return new WaitForSeconds(invincibleTime);
        ChangeAlpha(currentGameObeject.GetComponent<Renderer>().material, 1);
        invincible = false;

    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }
    public void Health()
    {
        if (health <= 0)
        {
            EndGame();
        }
        else
        {
            GameManager.gameOver = false;
        }

        switch (health)
        {

            case 3:

                health3.SetActive(true);
                health2.SetActive(false);
                health1.SetActive(false);
                break;

            case 2:
                health3.SetActive(false);
                health2.SetActive(true);
                health1.SetActive(false);
                break;

            case 1:
                health3.SetActive(false);
                health2.SetActive(false);
                health1.SetActive(true);

                break;

            default:
                health3.SetActive(false);
                health2.SetActive(false);
                health1.SetActive(false);

                break;




        }

    }
}