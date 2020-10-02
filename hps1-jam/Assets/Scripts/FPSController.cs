using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://github.com/jiankaiwang/FirstPersonController
/// </summary>
public class FPSController : MonoBehaviour
{
    public float speed = 10f;
    float translation;
    float strafe;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(strafe, 0 , translation);

    }
}
