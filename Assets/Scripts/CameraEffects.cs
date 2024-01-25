using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{

    public float shakeAmount = 0.1f;
    public int maxZoom = 1;
    public int minZoom = 50;

    private Transform camTransform;
    private Vector3 originalPos;
    private Quaternion originalRot;
    private Quaternion targetRot;
    private bool Turning = false;

    // Use this for initialization
    void Awake()
    {

        camTransform = gameObject.GetComponent(typeof(Transform)) as Transform;
        gameObject.GetComponent<Camera>().fieldOfView = maxZoom;
        originalPos = camTransform.localPosition;
        originalRot = camTransform.localRotation;
    }

    // Update is called once per frame
    void OnEnable()
    {

    }
    void FixedUpdate()
    {

        if (GameManager.Instance != null && GameManager.Instance.Boosting)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }

        if (gameObject.GetComponent<Camera>().fieldOfView != minZoom)
        {
            gameObject.GetComponent<Camera>().fieldOfView++;
        }

        // if (!Turning) {
        //     camTransform.
        // }

        // if (Random.Range (0, 11) == 1 && !Turning) {
        //     StartCoroutine (CameraTurn (Random.Range (-1, 2), Random.Range (1, 6), 5));

        // }

    }

    IEnumerator CameraTurn(int direction, int lenghtOfTurn, int speed)
    {
        Turning = true;
        camTransform.rotation = Quaternion.Lerp(camTransform.rotation, Quaternion.Euler(35, 30 * direction, -30 * direction), Time.deltaTime * speed);
        yield return new WaitForSeconds(lenghtOfTurn);
        camTransform.localPosition = originalPos;
        camTransform.rotation = Quaternion.Lerp(camTransform.rotation, originalRot, Time.deltaTime * speed);
        Turning = false;
    }

}