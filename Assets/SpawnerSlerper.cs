using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSlerper : Slerper
{
    protected void Update()
    {
        base.Update();
        ImageToFill.color = Color.Lerp(Color.black, Color.green, progress);
    }
}
