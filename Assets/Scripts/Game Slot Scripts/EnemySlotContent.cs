using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlotContent : MonoBehaviour
{
    RectTransform myRect;

    public Vector3 Position
    {
        get { return myRect.anchoredPosition; }
        set { myRect.anchoredPosition = value; }
    }

    public Vector3 Scale
    {
        get { return myRect.localScale; }
        set { myRect.localScale = value; }
    }

    private void Awake()
    {
        myRect = GetComponent<RectTransform>();
    }

    public void SetPositionAndScale(Vector3 position, Vector3 scale, float t)
    {
        myRect.anchoredPosition = Vector3.Lerp(Position, position, t);
        myRect.localScale = Vector3.Lerp(Scale, scale, t);
    }
}
