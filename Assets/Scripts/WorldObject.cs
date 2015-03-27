using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {

    public string objectName;
    public int hitPoints, maxHitPoints;

    protected Player player;
    protected string[] actions = { };
    protected bool currentlySelected = false;


    protected virtual void Awake()
    {

    }

	protected virtual void Start () 
    {
        player = transform.root.GetComponent<Player>();
	}
	
	protected virtual void Update () 
    {
	
	}

    public void setSelection(bool selected)
    {
        currentlySelected = selected;
    }

    public string[] getActions()
    {
        return actions;
    }

    public virtual void performAction(string actionToPerform)
    {

    }

    public virtual void mouseClick(GameObject hitObject, Vector3 hitPoint, Player controller)
    {
        if (currentlySelected && hitObject && hitObject.name != "Ground")
        {
            WorldObject worldObject = hitObject.transform.root.GetComponent<WorldObject>();
            if (worldObject) {
                changeSelection(worldObject, controller);
            }
        }
    }

    private void changeSelection(WorldObject worldObject, Player controller)
    {
        setSelection(false);
        if (controller.selectedObject) {
            controller.selectedObject.setSelection(false);
        }
        controller.selectedObject = worldObject;
        worldObject.setSelection(true);
    }
}
