using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public Camera cam;
    public int shotSpeed = 1000;
    public AudioSource audio1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = cam.transform.eulerAngles;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(bullet);
            obj.name = "bullet";
            obj.transform.position = transform.position;
            obj.GetComponent<Rigidbody>().AddRelativeForce(transform.forward*shotSpeed);
            audio1.PlayOneShot(audio1.clip);
            Destroy(obj, 5);
        }
    }
}
