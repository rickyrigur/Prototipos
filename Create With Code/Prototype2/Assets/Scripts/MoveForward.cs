using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Animal"))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        else if (gameObject.CompareTag("Pizza"))
            transform.Translate(Vector3.forward * Time.deltaTime * (speed * 3));
    }
}
