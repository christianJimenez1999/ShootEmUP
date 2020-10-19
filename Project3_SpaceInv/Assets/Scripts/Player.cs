using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    float amplify = 10;
    public GameObject particleEffect;
    private float life = 3;
    //public GameObject player;

    public Transform shottingOffset;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.tag == "user")
        {
            if (Mathf.Abs(transform.position.x) < 10)
            {
                transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * amplify);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
            animator.SetTrigger("Shoot");
            Destroy(shot, 0.5f);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("gameOver!");
            GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Debug.Log(particle);
            Destroy(particle, 1f);
            //Destroy(gameObject);
            animator.SetTrigger("Death");
            Destroy(collision.gameObject);
            //life = life - 1;
            //Time.timeScale = 0;
            //SceneManager.LoadScene(sceneName: "creditsScenes");
            if (collision.gameObject != null)
            {
                Invoke("replace", 0);
                //GameObject.Find("Player").GetComponent<Player>().replace();
            }
        }

    }

    void replace()
    {
        Debug.Log("replacing!");
            Invoke("transfer", 1);
    }

    void transfer()
    {
        SceneManager.LoadScene(sceneName: "creditsScenes");
    }
    

    //for future use in implementing in future
    /*void gameOver()
    {
        Time.timeScale = 0;
    }*/

}