using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    [SerializeField] private float followSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            Vector3 target = new Vector3(player.position.x, offset, player.position.z);
            transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);
        }
    }
}
