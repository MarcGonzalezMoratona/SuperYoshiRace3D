using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSuperPiranha : MonoBehaviour
{
    public GameObject superPiranha;
    GameObject obj;
    public float runSpeed = 2f;
    public float turnSpeed = 90f;
    bool changeDirection = false;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL5")
        {
            obj = new GameObject();
            obj = (GameObject)Instantiate(superPiranha, new Vector3(0f, -2f, 40f), superPiranha.transform.rotation);
            obj.transform.parent = transform;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL3")
        {
            obj = new GameObject();
            obj = (GameObject)Instantiate(superPiranha, new Vector3(0f, -0.5f, 40f), superPiranha.transform.rotation);
            obj.transform.parent = transform;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("IsRunning", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL3" || SceneManager.GetActiveScene().name == "LEVEL5")
        {
            if (changeDirection)
            {
                if (direction == 0)
                {
                    if (obj.transform.rotation.eulerAngles.y >= 180)
                    {
                        obj.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                    }
                    else
                    {
                        changeDirection = false;
                        direction++;
                    }
                }
                else if (direction == 1)
                {
                    if (obj.transform.rotation.eulerAngles.y < 180)
                    {
                        obj.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                    }
                    else
                    {
                        changeDirection = false;
                        direction--;
                    }
                }
            }
            else
            {
                if (direction == 0)
                {
                    if (obj.transform.position.z > 5) obj.transform.Translate(-transform.forward * runSpeed * Time.deltaTime, Space.World);
                    else changeDirection = true;
                }
                else if (direction == 1)
                {
                    if (obj.transform.position.z < 35) obj.transform.Translate(transform.forward * runSpeed * Time.deltaTime, Space.World);
                    else changeDirection = true;
                }
            }
        }
    }
}
