using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 50;
    private int clickDirectionChange = 1;

    private AudioSource sound;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();

        gameObject.GetComponentInChildren<Renderer>().material = GameManager.Instance.AssignPlayerColor(GameManager.Instance.PlayerMaterials);

        GameManager.Instance.playerMaterial = GameManager.Instance.AssignPlayerColor(GameManager.Instance.PlayerMaterials);
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().material = GameManager.Instance.playerMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.left * playerSpeed * clickDirectionChange;
            clickDirectionChange *= -1;
            this.GetComponent<AudioSource>().Play();
        }

        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Left) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = Vector3.left * playerSpeed;
            this.GetComponent<AudioSource>().Play();

        }
        if (SwipeManager.Instance.IsSwiping(SwipeDirection.Right) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = Vector3.right * playerSpeed;
            this.GetComponent<AudioSource>().Play();

        }

        

    }

    public void PlaySound()
    {
        // if (AudioManager.Instance.comboNotesPosition >= AudioManager.Instance.notes.Length)
        // {
        //     AudioManager.Instance.comboNotesPosition = 0;
        // }
        // sound.clip = AudioManager.Instance.notes[AudioManager.Instance.comboNotesPosition];
        // sound.Play();
        // AudioManager.Instance.comboNotesPosition++;


    }

}