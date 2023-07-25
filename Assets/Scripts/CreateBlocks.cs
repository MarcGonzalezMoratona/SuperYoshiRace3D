using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateBlocks : MonoBehaviour
{
    public GameObject block;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL4")
        {
            for (int i = 0; i < 25; ++i)
            {
                obj = (GameObject)Instantiate(block, new Vector3(i - 12.0f, 0.35f, 20.0f), block.transform.rotation);
                obj.transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL1")
        {
            for (int i = 0; i < 80; ++i)
            {
                obj = (GameObject)Instantiate(block, new Vector3(0f, 0.35f, -1.5f + i), block.transform.rotation);
                obj = (GameObject)Instantiate(block, new Vector3(0f, 1.35f, -1.5f + i), block.transform.rotation);
                obj.transform.parent = transform;
            }
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL5")
        {
        }
        else if (SceneManager.GetActiveScene().name == "LEVEL2") { }
        else if (SceneManager.GetActiveScene().name == "LEVEL3") {
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
