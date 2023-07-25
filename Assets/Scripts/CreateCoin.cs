using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCoin : MonoBehaviour
{
    public GameObject coin;
    float turnSpeed = 90f;
    public GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL1") {

        }
        else if (SceneManager.GetActiveScene().name == "LEVEL2") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL3") {
            obj = new GameObject[12];
            for (int i = 0; i < obj.Length; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(coin, new Vector3(-3.0f, 1.0f, 50.0f + 2*i), coin.transform.rotation);
                else obj[i] = (GameObject)Instantiate(coin, new Vector3(3.0f, 1.0f, 50.0f + 2*i), coin.transform.rotation);
                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL4")
        {
            obj = new GameObject[12];
            for (int i = 0; i < obj.Length; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(coin, new Vector3(-3.0f, 1.0f, 30.0f + 2*i), coin.transform.rotation);
                else obj[i] = (GameObject)Instantiate(coin, new Vector3(3.0f, 1.0f, 30.0f + 2*i), coin.transform.rotation);
                obj[i].transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL5") {
            obj = new GameObject[10];
            for (int i = 0; i < obj.Length; ++i)
            {
                obj[i] = (GameObject)Instantiate(coin, new Vector3(0f, -2.0f, 10.0f + 2 * i), coin.transform.rotation);
                obj[i].transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < obj.Length; ++i)
        {
            if (obj[i])
            {
                if (i % 2 == 0) obj[i].transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                else obj[i].transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }
        }
    }
}
