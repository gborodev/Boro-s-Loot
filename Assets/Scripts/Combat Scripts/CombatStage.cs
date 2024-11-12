using UnityEngine;

public class CombatStage : MonoBehaviour
{
    [SerializeField] private EnemySlot[] _slots;

    private RectTransform rect;

    public Vector3 LastPosition { get; set; } = Vector3.zero;
    public Vector3 LastScale { get; set; } = Vector3.zero;

    public Vector3 Position
    {
        get => rect.anchoredPosition;

        set
        {
            rect.anchoredPosition = value;
        }
    }

    public Vector3 Scale
    {
        get => rect.localScale;

        set
        {
            rect.localScale = value;
        }
    }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

}
