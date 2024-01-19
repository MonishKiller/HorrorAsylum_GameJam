using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    // Accessor property to get the instance of the singleton
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // Check if an instance of the singleton exists in the scene
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    // If not, create a new GameObject and add the singleton component to it
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    // Ensure the singleton is not duplicated when the scene is loaded
    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
}
