using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when an object exits the trigger.")]
    [TaskCategory("Physics")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=110")]
    public class HasExitedTrigger : Conditional
    {
        [Tooltip("The object that exited the trigger")]
        public SharedGameObject otherGameObject;

        private bool exitedTrigger = false;

        public override TaskStatus OnUpdate()
        {
            return exitedTrigger ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnEnd()
        {
            exitedTrigger = false;
        }

        public override void OnTriggerExit(Collider other)
        {
            otherGameObject.Value = other.gameObject;
            exitedTrigger = true;
        }

        public override void OnReset()
        {
            otherGameObject = null;
        }
    }
}