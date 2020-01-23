using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.NextDayDelivery.Scripts.FSM.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Unity-FSM/States/Idle", order = 1)]
    public class IdleState: AbstractFSMState
    {
        public override bool EnterState()
        {
            base.EnterState();
            Debug.Log("ENTERED IDLE STATE");
            return true;
        }

        public override void UpdtateState()
        {
            Debug.Log("UPDATING STATE");
        }

        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("EXITING IDLE STATE");
            return true;
        }
    }
}
