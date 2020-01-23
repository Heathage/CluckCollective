using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.NextDayDelivery.Scripts.Enemy
{
    public class EnemeyPatrolRoute: MonoBehaviour
    {
        [SerializeField]
        bool _patrolWaiting;

        [SerializeField]
        float _totalWaitTime = 3f;

        [SerializeField]
        float _switchProbability = 0f;

        NavMeshAgent _navMeshAgent;
        int _currentPatrolIndex;
        bool _travelling;
        bool _waiting;
        bool _patrolForward;
        float _waitTimer;

        public void Start()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>();

        }
    }
}
