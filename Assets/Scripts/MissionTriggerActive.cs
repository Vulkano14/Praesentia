using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTriggerActive : MonoBehaviour
{
    [SerializeField] ManagerMission _managerMission;

    bool _canActiveTrigger = true;

    void OnTriggerEnter(Collider other)
    {

        if (_canActiveTrigger)
        {
            if (other.CompareTag("Player") && _canActiveTrigger && !_managerMission._canIActivateNextMission)
            {
                _canActiveTrigger = false;
                StartCoroutine(_managerMission.ActivateMission());
                Destroy(gameObject, 11f);
            }

            if (other.CompareTag("Player") && _managerMission._canIActivateNextMission && _canActiveTrigger)
            {
                _canActiveTrigger = false;
                StartCoroutine(_managerMission.DeactivateMission());
                Destroy(gameObject, 18f);
            }
        } 
    }
}
