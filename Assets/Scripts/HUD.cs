using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    private Player player;
    public int hudHeight;

	// Use this for initialization
	void Start () {
        player = transform.root.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool mouseInBounds()
    {
        Vector3 mousePos = Input.mousePosition;
        bool insideWidth = mousePos.x >= 0 && mousePos.x <= Screen.width;
        bool insideHeight = mousePos.y >= hudHeight && mousePos.y <= Screen.height;
        return insideHeight && insideWidth;
    }
}
