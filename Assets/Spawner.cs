using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField, Min(0.1f)] private float spawnsPerSecond = 0.1f;
    [SerializeField, Min(1f)] private float innerSpawnDisc = 4;
    [SerializeField, Min(1.1f)] private float outerSpawnDisc = 8;
    [SerializeField, Min(1f)] private float ingredientSpeed = 10;
    [SerializeField] private List<GameObject> ingredients = new List<GameObject>();

    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredients.Count == 0) {
            return;
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 1 / spawnsPerSecond)
        {
            spawnTimer -= 1 / spawnsPerSecond;
            var ingredientIndex = Random.Range(0, ingredients.Count);
            var ingredientTemplate = ingredients[ingredientIndex];
            var angle = Random.Range(0f, System.MathF.PI * 2f);
            var radius = Random.Range(innerSpawnDisc, outerSpawnDisc);
            var position = PointOnDiscAt(angle, radius);
            var scale = ingredientTemplate.transform.localScale;
            var maxAxis = System.MathF.Max(scale.x, System.MathF.Max(scale.y, scale.z));

            if (Physics.OverlapSphere(position, maxAxis).Length == 0) 
            {
                var ingredientObject = Instantiate(ingredientTemplate, position, Quaternion.identity);
                var targetAngle = angle + Random.Range(System.MathF.PI / 16f, System.MathF.PI / 8f);
                var targetPoint = PointOnDiscAt(targetAngle, radius);
                var toTarget = targetPoint - position;
                var velocity = toTarget * ingredientSpeed;

                ingredientObject.GetComponent<Rigidbody>().AddForce(velocity);
            }
        }
    }

    Vector3 PointOnDiscAt(float angle, float radius)
    {
        var x = radius * System.MathF.Cos(angle);
        var z = radius * System.MathF.Sin(angle);
        var position = new Vector3(x, 1.4f, z);

        return position;
    }
}
