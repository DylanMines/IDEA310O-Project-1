using Unity.VisualScripting;
using UnityEngine;

public class RightClickCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        MonoBehaviour controller;
        foreach (MonoBehaviour mb in scripts)
        {
            if (mb.name == "Third Person Controller")
            {
                controller = mb;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
