using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCow : MonoBehaviour
{
    public GameObject cow;
    public float runSpeed = 3f;
    public float turnSpeed = 90f;
    GameObject[] obj;
    bool changeDirection = false;
    int[] direction;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL2")
        {
            obj = new GameObject[2];
            direction = new int[4];
            for (int i = 0; i < 2; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(cow, new Vector3(-4f, 0.7f + i * 0.55f, 40f), cow.transform.rotation);
                else obj[i] = (GameObject)Instantiate(cow, new Vector3(4f, 0.7f + (i - 1) * 0.55f, 40f), cow.transform.rotation);
                obj[i].transform.parent = transform;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL2")
        {
            for (int i = 0; i < obj.Length; ++i)
            {
                if (changeDirection)
                {
                    if (i % 2 == 0)
                    {
                        if (direction[i] == 0)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y <= 90) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else if (direction[i] == 1)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y <= 180) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else if (direction[i] == 2)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y <= 270) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else if (direction[i] == 3)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y > 270) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else direction[i] = 0;
                    }
                    else
                    {
                        if (direction[i] == 0)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y >= 270) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else if (direction[i] == 1)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y >= 180) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else if (direction[i] == 2)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y >= 90) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else if (direction[i] == 3)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y < 90) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                            }
                        }
                        else direction[i] = 0;
                    }
                }
                else
                {
                    if (direction[i] == 0)
                    {
                        if (obj[i].transform.position.z > 28) obj[i].transform.Translate(-transform.forward * runSpeed * Time.deltaTime, Space.World);
                        else changeDirection = true;
                    }
                    else if (direction[i] == 1)
                    {
                        if (i % 2 == 0)
                        {
                            if (obj[i].transform.position.x > -12) obj[i].transform.Translate(-transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                        else
                        {
                            if (obj[i].transform.position.x < 12) obj[i].transform.Translate(transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                    }
                    else if (direction[i] == 2)
                    {
                        if (obj[i].transform.position.z < 40) obj[i].transform.Translate(transform.forward * runSpeed * Time.deltaTime, Space.World);
                        else changeDirection = true;
                    }
                    else if (direction[i] == 3)
                    {
                        if (i % 2 == 0)
                        {
                            if (obj[i].transform.position.x < -4) obj[i].transform.Translate(transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                        else
                        {
                            if (obj[i].transform.position.x > 4) obj[i].transform.Translate(-transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                    }
                    else direction[i] = 0;
                }
            }
        }
    }
}
