using UnityEngine;
using System.Collections;

public class Building : WorldObject {

    protected override void Awake()
    {
        base.Awake();
    }

	protected override void Start () 
    {
        base.Start();
	}

    protected override void Update()
    {
        base.Update();
    }

    private void leftMouseClick()
    {
        if (player.hud.mouseInBounds()) {
            GameObject hitObject = findHitPoint();
        }
    }
}
