using UnityEngine;
using System.Collections;
using RTS;

public class UserInput : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () 
    {
        player = transform.GetComponent<Player>();
  
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (player.human) {
            moveCamera();
            rotateCamera();
        }
	}

    private void moveCamera() 
    {
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;
        Vector3 movement = new Vector3(0, 0, 0);

        //horizontal camera movement
        if (xpos >= 0 && xpos < RTSManager.ScrollWidth)
        {
            movement.x -= RTSManager.ScrollSpeed;
        }
        else if (xpos <= Screen.width && xpos > Screen.width - RTSManager.ScrollWidth)
        {
            movement.x += RTSManager.ScrollSpeed;
        }

        //vertical camera movement
        if (ypos >= 0 && ypos < RTSManager.ScrollWidth)
        {
            movement.z -= RTSManager.ScrollSpeed;
        }
        else if (ypos <= Screen.height && ypos > Screen.height - RTSManager.ScrollWidth)
        {
            movement.z += RTSManager.ScrollSpeed;
        }

        //make sure movement is in the direction the camera is pointing
        //but ignore the vertical tilt of the camera to get sensible scrolling
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;

        //away from ground movement
        movement.y -= RTSManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");

        //calculate desired camera position based on received input
        Vector3 origin = Camera.main.transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;

        //limit away from ground movement to be between a minimum and maximum distance
        if (destination.y > RTSManager.MaxCameraHeight)
        {
            destination.y = RTSManager.MaxCameraHeight;
        }
        else if (destination.y < RTSManager.MinCameraHeight)
        {
            destination.y = RTSManager.MinCameraHeight;
        }

        //if a change in position is detected perform the necessary update
        if (destination != origin)
        {
            Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * RTSManager.ScrollSpeed);
        }
    }

    private void rotateCamera()
    {
        Vector3 origin = Camera.main.transform.eulerAngles;
        Vector3 destination = origin;

        //detect rotation amount if ALT is being held and the Right mouse button is down
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetMouseButton(1))
        {
            destination.x -= Input.GetAxis("Mouse Y") * RTSManager.RotateAmount;
            destination.y += Input.GetAxis("Mouse X") * RTSManager.RotateAmount;
        }

        //if a change in position is detected perform the necessary update
        if (destination != origin)
        {
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * RTSManager.RotateSpeed);
        }
    }

    private GameObject findHitObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) return hit.collider.gameObject;
        return null;

    }

    private Vector3 findHitPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) return hit.point;
        return RTSManager.InvalidPosition;
    }
}
