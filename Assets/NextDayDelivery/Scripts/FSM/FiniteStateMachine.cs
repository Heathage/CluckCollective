using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.NextDayDelivery.Scripts.FSM
{
    public class FiniteStateMachine: MonoBehaviour
    {
        [SerializeField]
        AbstractFSMState _startingState;

        AbstractFSMState _currentState;


        public void Awake()
        {
            _currentState = null;
        }

        public void Start()
        {
            if(_startingState != null)
            {
                EnterState(_startingState);
            }
        }

        public void Update()
        {
            if(_currentState != null)
            {
                _currentState.UpdtateState();
            }
        }

        #region State Management

        public void EnterState(AbstractFSMState nextState)
        {
            if (_startingState == null)
            {
                return;
            }

            _currentState = nextState;
            _currentState.EnterState();
        }
        #endregion
    }
}