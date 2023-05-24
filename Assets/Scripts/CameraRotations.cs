using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotations : MonoBehaviour
{
    [SerializeField] Camera myCamera;

    [SerializeField] private float sensitivity = 0.07f;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private Transform cameraWalkingPos;
    [SerializeField] private Transform cameraRidingPos;
    [SerializeField] private GameObject HobbitWalkingArms;
    [SerializeField] private GameObject HobbitRidingArms;
    private Transform currentCameraPos;
    private AudioSource bikeChain;

    private int cameraMovementSpeed = 3;

    public bool positionUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        currentCameraPos = cameraWalkingPos;
        bikeChain = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (positionUpdated)
        {
            positionUpdated = false;
            Invoke(nameof(updateCameraPosition), 0.3f);
        }

        myCamera.transform.position = Vector3.MoveTowards(myCamera.transform.position, currentCameraPos.position, cameraMovementSpeed * Time.deltaTime);
    }

    private void updateCameraPosition()
    {
        if (currentCameraPos.position == cameraWalkingPos.position)
        {
            currentCameraPos = cameraRidingPos;
            bikeChain.Play();
        }
        else
        {
            currentCameraPos = cameraWalkingPos;
            bikeChain.Stop();
        }
        HobbitWalkingArms.SetActive(!HobbitWalkingArms.activeSelf);
        HobbitRidingArms.SetActive(!HobbitRidingArms.activeSelf);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vp = myCamera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, myCamera.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity * Time.deltaTime * 10;
        vp.y *= sensitivity * Time.deltaTime * 10;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = myCamera.ViewportToScreenPoint(vp);

        Vector3 v = myCamera.ScreenToWorldPoint(sp);

        transform.LookAt(v, Vector3.up);

        //transform.LookAt(myCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, myCamera.nearClipPlane)), Vector3.up);
    }
}
