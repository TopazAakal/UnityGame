using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Vector2 turn;
    public float speed = 2;
    public GameObject player;
    public int cam;
    public GameObject scope;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        scope.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            turn.x += Input.GetAxis("Mouse X") * speed;
            turn.y += Input.GetAxis("Mouse Y") * speed;

            turn.y=Mathf.Clamp(turn.y, -30, 25);

            player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
            transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (cam == 0)
            {
                transform.localPosition = new Vector3(1, 14.8f, -19.7f);
                transform.localEulerAngles = new Vector3(10.898f, 0, 0);
                scope.SetActive(false);
            }
            if (cam == 1)
            {
                transform.localPosition = new Vector3(0.4f, 10.8f, -1.2f);
                transform.localEulerAngles = new Vector3(5.501f, 0, 0);
                scope.SetActive(true);

            }

            cam += 1;

            if (cam == 2)
            {
                cam = 0;
            }
        }
    }
}
