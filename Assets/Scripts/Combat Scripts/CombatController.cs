using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [Header("Database")]
    [SerializeField] private Database _database;

    [Header("Panels")]
    [SerializeField] private Transform _combatPanel;

    [Header("Prefabs")]
    [SerializeField] private CombatStage _combatStagePrefab;

    [Header("Combat Control Variables")]
    [SerializeField][Range(0.1f, 1f)] private float _combatMovingTime = 1f;

    private readonly int frontY = -100;
    private readonly int startY = 300;
    private readonly int stageSpacing = 200;

    private List<CombatStage> _combatStages;
    private readonly int minStageSize = 3;

    private List<EnemyData> _enemies;

    private CombatStage _currentStage;

    private void OnEnable()
    {
        GameEvents.StageEvents.OnStageStarted += InitializeEnemies;
        GameEvents.StageEvents.OnStageCompleted += StageComplete;
    }

    private void InitializeEnemies()
    {
        _enemies = new List<EnemyData>();

        foreach (EnemyData enemy in _database.enemies)
        {
            if (enemy.LevelRequirement <= GameManager.instance.GameLevel)
            {
                _enemies.Add(enemy);
            }
        }

        InitializeStageBegin();
    }

    private void InitializeStageBegin()
    {
        _combatStages = new List<CombatStage>();

        while (_combatStages.Count < minStageSize)
        {
            Vector3 position = new Vector3(0, startY + (_combatStages.Count * stageSpacing), 0);

            StageInstantiate(position);
        }

        StartCoroutine(StageMoverCoroutine());
    }

    public void StageComplete()
    {
        _combatStages.RemoveAt(0);

        Vector3 instantiatePosition = new Vector3(0, _combatStages[^1].Position.y + stageSpacing, 0);
        StageInstantiate(instantiatePosition);

        StartCoroutine(StageMoverCoroutine());
    }

    private IEnumerator StageMoverCoroutine()
    {
        float timer = 0;

        while (timer < _combatMovingTime)
        {
            timer += Time.deltaTime;

            float normalizedTime = timer / _combatMovingTime;

            for (int i = 0; i < _combatStages.Count; i++)
            {
                CombatStage stage = _combatStages[i];

                Vector3 newPosition = new Vector3(0, frontY + (i * stageSpacing), 0);
                Vector3 newScale = new Vector3(1f - ((float)i / (_combatStages.Count - 1)), 1f - ((float)i / (_combatStages.Count - 1)), 1);

                stage.Position = Vector3.Lerp(stage.LastPosition, newPosition, normalizedTime);
                stage.Scale = Vector3.Lerp(stage.LastScale, newScale, normalizedTime);
            }

            yield return null;
        }

        for (int i = 0; i < _combatStages.Count; i++)
        {
            CombatStage stage = _combatStages[i];

            stage.LastPosition = stage.Position;
            stage.LastScale = stage.Scale;
        }

        GameEvents.StageEvents.OnStageSelected?.Invoke(_combatStages[0]);
    }


    private void StageInstantiate(Vector3 position)
    {
        CombatStage combatStage = Instantiate(_combatStagePrefab, _combatPanel, true);
        combatStage.Position = position;

        combatStage.LastPosition = combatStage.Position;
        combatStage.LastScale = combatStage.Scale;

        _combatStages.Add(combatStage);
    }
}
