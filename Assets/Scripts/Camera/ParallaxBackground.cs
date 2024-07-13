using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public static ParallaxBackground Instance;


    private void Awake()
    {
        Instance = this;
    }

    private Transform theCam;

    public Transform sky, treeline;

    [Range(0f, 1f)]
    public float parallaxSpeed;


    void Start()
    {
        theCam = Camera.main.transform;
        
    }

    void LateUpdate()
    {

    }



    public void MoveBackground()
    {
        sky.position = new Vector3(theCam.position.x, theCam.position.y, sky.position.z);

        treeline.position = new Vector3(
            theCam.position.x * parallaxSpeed,
            theCam.position.y,
            treeline.position.z);
    }
}
