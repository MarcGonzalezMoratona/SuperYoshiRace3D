using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSphinx : MonoBehaviour
{
    public GameObject sphinx;
    GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LEVEL3")
        {
            obj = new GameObject[4];
            for (int i = 0; i < 4; ++i)
            {
                if (i % 2 == 0) obj[i] = (GameObject)Instantiate(sphinx, new Vector3(-4.6f, -0.5f, 12f + i * 10f), sphinx.transform.rotation);
                else
                {
                    obj[i] = (GameObject)Instantiate(sphinx, new Vector3(4.6f, -0.5f, 12f + i * 10f), sphinx.transform.rotation);
                    obj[i].transform.Rotate(0, 180, 0);
                }
                obj[i].transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
