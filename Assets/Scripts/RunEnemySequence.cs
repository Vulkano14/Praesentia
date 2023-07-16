using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemySequence : MonoBehaviour
{
    [SerializeField] Transform _player;
    public float moveSpeed = 4.7f;

    public bool canRun = false;

    void Update()
    {
        if (canRun)
        {
            Vector3 direction = new Vector3(_player.position.x, transform.position.y, _player.position.z) - transform.position;
            direction.Normalize();

            Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

            transform.position = newPosition;

            transform.LookAt(new Vector3(_player.position.x, transform.position.y, _player.position.z));
        }
    }

}
