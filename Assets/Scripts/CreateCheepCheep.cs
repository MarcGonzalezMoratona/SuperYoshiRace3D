using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCheepCheep : MonoBehaviour
{
    public GameObject cheepcheep;
    public float runSpeed = 7f;
    public float jumpHeight = 9f;
    GameObject[] obj;
    Rigidbody[] rb;
    bool[] isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL5")
        {
            isGrounded = new bool[2];
            obj = new GameObject[2];
            rb = new Rigidbody[2];
            for (int i = 0; i < 2; ++i)
            {
                isGrounded[i] = true;
                obj[i] = (GameObject)Instantiate(cheepcheep, new Vector3(-10f + 20f * i, -2.5f, 110f), cheepcheep.transform.rotation);
                obj[i].transform.parent = transform;
                rb[i] = obj[i].GetComponent<Rigidbody>();
                if (i % 2 == 1) obj[i].transform.Rotate(0, 0, 180);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL5")
        {
            for (int i = 0; i < 2; ++i)
            {
                if (i % 2 == 0)
                {
                    obj[i].transform.Translate(transform.right * runSpeed * Time.deltaTime, Space.World);

                    if (isGrounded[i])
                    {
                        if (rb[i].velocity == Vector3.zero) rb[i].AddForce(new Vector3(0f, 1f, 0f) * jumpHeight, ForceMode.Impulse);
                        isGrounded[i] = false;
                    }
                    else if (obj[i].transform.position.y <= -2.5f)
                    {
                        obj[i].transform.position = new Vector3(-10f + 20f * i, -2.5f, 110f);
                        rb[i].velocity = Vector3.zero;
                        isGrounded[i] = true;
                    }
                }
                else
                {
                    obj[i].transform.Translate(-transform.right * runSpeed * Time.deltaTime, Space.World);

                    if (isGrounded[i])
                    {
                        if (rb[i].velocity == Vector3.zero) rb[i].AddForce(new Vector3(0f, 1f, 0f) * jumpHeight, ForceMode.Impulse);
                        isGrounded[i] = false;
                    }
                    else if (obj[i].transform.position.y <= -2.5f)
                    {
                        obj[i].transform.position = new Vector3(-10f + 20f * i, -2.5f, 110f);
                        rb[i].velocity = Vector3.zero;
                        isGrounded[i] = true;
                    }
                }

            }
        }
    }
}
