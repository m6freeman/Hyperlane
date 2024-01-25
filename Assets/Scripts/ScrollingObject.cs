using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{


    private Rigidbody rb;
    public bool wasHit = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, GameManager.Instance.speed * -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameOver == true)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, GameManager.Instance.speed * -1);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            //DEATH CONDITION
            if (other.gameObject.GetComponentInChildren<Renderer>().material.name != gameObject.GetComponentInChildren<SpriteRenderer>().material.name)
            {
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                other.gameObject.GetComponentInChildren<Renderer>().enabled = false;
                StartCoroutine(GameManager.Instance.PlayerDied());
            }
            //SUCCESS CONDITION
            else
            {
                gameObject.GetComponent<AudioSource>().Play();
                StartCoroutine(SpeedUp(0.5F));
                GameManager.Instance.PlayerScored();
                gameObject.GetComponent<ScrollingObject>().wasHit = true;
                GameManager.Instance.playerMaterial = GameManager.Instance.AssignPlayerColor(GameManager.Instance.PlayerMaterials);
                foreach (Transform child in other.transform)
                {
                    child.gameObject.GetComponent<Renderer>().material = GameManager.Instance.playerMaterial;
                }
            }
        }

    }

    IEnumerator SpeedUp(float lenghtOfTime)
    {
        GameManager.Instance.Boosting = true;
        Time.timeScale = 2;
        yield return new WaitForSeconds(lenghtOfTime);
        GameManager.Instance.Boosting = false;
        Time.timeScale = 1;
    }
}