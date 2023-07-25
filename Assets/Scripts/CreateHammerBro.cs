using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateHammerBro : MonoBehaviour
{
    public GameObject hammerBro;
    GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL4")
        {

        }
        else if (SceneManager.GetActiveScene().name == "LEVEL1") {

        }
        else if (SceneManager.GetActiveScene().name == "LEVEL5") {
            obj = new GameObject[2];

            for (int i = 0; i < 2; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(hammerBro, new Vector3(-10f, -0.5f, 15f), hammerBro.transform.rotation);
                else
                {
                    obj[i] = (GameObject)Instantiate(hammerBro, new Vector3(10f, -0.5f, 15f), hammerBro.transform.rotation);
                    obj[i].transform.Rotate(0, 180, 0);
                }
                obj[i].transform.parent = transform;
                transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("IsThrowing", true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL2") {
            obj = new GameObject[2];

            for (int i = 0; i < 2; ++i)
            {
                if (i % 2 == 0)
                {
                    obj[i] = (GameObject)Instantiate(hammerBro, new Vector3(-8f, 2.9f, 63f), hammerBro.transform.rotation);
                    obj[i].transform.Rotate(0, 90, 0);

                }
                else
                {
                    obj[i] = (GameObject)Instantiate(hammerBro, new Vector3(8f, 2.9f, 63f), hammerBro.transform.rotation);
                    obj[i].transform.Rotate(0, 90, 0);
                }
                obj[i].transform.parent = transform;
                transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("IsThrowing", true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL3")
        {
            obj = new GameObject[6];

            for (int i = 0; i < 6; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(hammerBro, new Vector3(-11f, 3f, 50f + i * 5f), hammerBro.transform.rotation);
                else
                {
                    obj[i] = (GameObject)Instantiate(hammerBro, new Vector3(11f, 3f, 50f + (i - 1) * 5f), hammerBro.transform.rotation);
                    obj[i].transform.Rotate(0, 180, 0);
                }
                obj[i].transform.parent = transform;
                transform.GetChild(i).gameObject.GetComponent<Animator>().SetBool("IsThrowing", true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
