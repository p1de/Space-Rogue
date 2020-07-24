using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public static Vector2 direction;
    void FixedUpdate()
    {
        if (PauseMenu.isPaused == false && UpgradeMenu.isUpgrading == false) mouseAim();
    }
    void mouseAim()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
