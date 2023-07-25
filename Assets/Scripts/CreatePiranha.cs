using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatePiranha : MonoBehaviour
{
    public GameObject piranha;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "LEVEL1")
        //{
        //    for (int i = 0; i < 2; ++i)
        //    {
        //        if (i % 2 == 0) obj = (GameObject)Instantiate(piranha, new Vector3(-9.0f, -0.5f, 60.0f), piranha.transform.rotation);
        //        else
        //        {
        //            obj = (GameObject)Instantiate(piranha, new Vector3(9.0f, -0.5f, 60.0f), piranha.transform.rotation);
        //            obj.transform.Rotate(0.0f, 180.0f, 0.0f);
        //        }
        //        obj.transform.parent = transform;
        //    }
        //}
        //else if (SceneManager.GetActiveScene().name == "LEVEL2") {
        //    for(int i = 0; i < 4; ++i)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            obj = (GameObject)Instantiate(piranha, new Vector3(-6.0f, -2f, 22f + i * 8), piranha.transform.rotation);
        //        }
        //        else
        //        {
        //            obj = (GameObject)Instantiate(piranha, new Vector3(6.0f, -2f, 22f + (i - 1) * 8), piranha.transform.rotation);
        //            obj.transform.Rotate(0, 180, 0);
        //        }
        //        obj.transform.parent = transform;
        //    }
        //}
        //else if (SceneManager.GetActiveScene().name == "LEVEL3") { }
        //else if (SceneManager.GetActiveScene().name == "LEVEL4") { }
        //else if (SceneManager.GetActiveScene().name == "LEVEL5") { }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
