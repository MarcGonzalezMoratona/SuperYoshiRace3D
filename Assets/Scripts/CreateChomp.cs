using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateChomp : MonoBehaviour
{
    public GameObject chomp;
    public float runSpeed = 12f;
    public float turnSpeed = 90f;
    GameObject[] obj;
    bool changeDirection = false;
    int[] direction;
    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL4")
        {
            obj = new GameObject[2];
            direction = new int[4];
            for (int i = 0; i < 2; ++i)
            {
                if (i % 2 == 0)
                {
                    obj[i] = (GameObject)Instantiate(chomp, new Vector3(-6f, 2.5f, 60f), chomp.transform.rotation);
                    obj[i].transform.Rotate(0f, -90f, 0f);
                }
                else
                {
                    obj[i] = (GameObject)Instantiate(chomp, new Vector3(6f, 2.5f, 60f), chomp.transform.rotation);
                    obj[i].transform.Rotate(0f, -90f, 0f);
                }
                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL1") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL2") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL3") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL5") { }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL4")
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
                                AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else if (direction[i] == 1)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y <= 180) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                                //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else if (direction[i] == 2)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y <= 270) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                                AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else if (direction[i] == 3)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y > 270) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                                //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
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
                                //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else if (direction[i] == 1)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y >= 180) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                                //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else if (direction[i] == 2)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y >= 90) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                                //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else if (direction[i] == 3)
                        {
                            if (obj[i].transform.rotation.eulerAngles.y < 90) obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                            else
                            {
                                changeDirection = false;
                                direction[i]++;
                                //AudioSource.PlayClipAtPoint(soundEffect, obj[i].transform.position);
                            }
                        }
                        else direction[i] = 0;
                    }
                }
                else
                {
                    if (direction[i] == 0)
                    {
                        if (obj[i].transform.position.z > 25) obj[i].transform.Translate(-transform.forward * runSpeed * Time.deltaTime, Space.World);
                        else changeDirection = true;
                    }
                    else if (direction[i] == 1)
                    {
                        if (i % 2 == 0)
                        {
                            if (obj[i].transform.position.x > -6) obj[i].transform.Translate(-transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                        else
                        {
                            if (obj[i].transform.position.x < 6) obj[i].transform.Translate(transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                    }
                    else if (direction[i] == 2)
                    {
                        if (obj[i].transform.position.z < 60) obj[i].transform.Translate(transform.forward * runSpeed * Time.deltaTime, Space.World);
                        else changeDirection = true;
                    }
                    else if (direction[i] == 3)
                    {
                        if (i % 2 == 0)
                        {
                            if (obj[i].transform.position.x < -3) obj[i].transform.Translate(transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                        else
                        {
                            if (obj[i].transform.position.x > 3) obj[i].transform.Translate(-transform.right * runSpeed * Time.deltaTime, Space.World);
                            else changeDirection = true;
                        }
                    }
                    else direction[i] = 0;
                }
            }
        }
    }
}
