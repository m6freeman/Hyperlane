using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{

    public GameObject player;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<SpriteRenderer> ().material.name == player.gameObject.GetComponentInChildren<Renderer> ().material.name
            && other.gameObject.GetComponent<ScrollingObject>().wasHit == false)
        {
            GameManager.Instance.BreakCombo();
        }

    }
}
