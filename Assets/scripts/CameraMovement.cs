using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  
    [SerializeField]Transform playerCarTransform;
    [SerializeField] float offset=-5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerCarTransform.position.z + offset;
        transform.position=cameraPos;
    }
}
