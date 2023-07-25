using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL1")
        {
            for (int i = 0; i < 2; ++i)
            {
                obj = (GameObject)Instantiate(checkpoint, new Vector3(4.5f - i * 9.0f, 1.65f, 30.0f), checkpoint.transform.rotation);
                obj.transform.Rotate(0, 0, (i - 1) * 180);
                obj.transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL2")
        {
            for (int i = 0; i < 2; ++i)
            {
                obj = (GameObject)Instantiate(checkpoint, new Vector3(6.0f - i * 12.0f, 1.65f, 58.5f), checkpoint.transform.rotation);
                obj.transform.Rotate(0, 0, (i - 1) * 180);
                obj.transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL3")
        {
            for (int i = 0; i < 2; ++i)
            {
                obj = (GameObject)Instantiate(checkpoint, new Vector3(0.5f - i * 5.0f, 1.65f, 43.5f), checkpoint.transform.rotation);
                obj.transform.Rotate(0, 0, (i - 1) * 180);
                obj.transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL4")
        {
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL5")
        {
            for (int i = 0; i < 2; ++i)
            {
                obj = (GameObject)Instantiate(checkpoint, new Vector3(4.5f - i * 9.0f, 1.65f, 28.0f), checkpoint.transform.rotation);
                obj.transform.Rotate(0, 0, (i - 1) * 180);
                obj.transform.parent = transform;
            }
            for (int i = 0; i < 2; ++i)
            {
                obj = (GameObject)Instantiate(checkpoint, new Vector3(7.0f - i * 14.0f, 1.65f, 100.0f), checkpoint.transform.rotation);
                obj.transform.Rotate(0, 0, (i - 1) * 180);
                obj.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
