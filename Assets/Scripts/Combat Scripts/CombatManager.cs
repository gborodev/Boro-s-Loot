using UnityEngine.InputSystem;

public class CombatManager : Singleton<CombatManager>
{
    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            GameEvents.StageEvents.OnStageCompleted?.Invoke();
        }
    }
}
