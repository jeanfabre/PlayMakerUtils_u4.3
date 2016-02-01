// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.
/*--- __ECO__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Physics)]
	[Tooltip("Set a Rigidbody position. It's more efficient then accessing the transform of the gameObject.")]
	public class SetRigidbodyPosition : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Rigidbody))]
		[Tooltip("The rigid body to rotate.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("The position.")]
		public FsmVector3 position;
		
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		
		[Tooltip("Repeat every frame.")]
		public bool everyFrame;
		
		private Rigidbody rigidBody;
		
		public override void Reset()
		{
			gameObject = null;
			position = null;
			x = new FsmFloat { UseVariable = true };
			y = new FsmFloat { UseVariable = true };
			z = new FsmFloat { UseVariable = true };
			everyFrame = true;
		}

        public override void Awake()
        {
            Fsm.HandleFixedUpdate = true;
        }
		
		public override void OnEnter()
		{

			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				LogError("Missing gameObject target");
				return;
			}
			
			rigidBody = go.GetComponent<Rigidbody>();
			if (rigidBody == null)
			{
				LogError("Missing Rigidbody component");
				return;
			}
				
		}

        public override void OnFixedUpdate()
        {
            DoPosition();
           
            if (!everyFrame)
            {
                Finish();
            }
        }

		void DoPosition()
		{
			if (rigidBody != null)
			{
				Vector3 _pos = rigidBody.position;
				
				if (!position.IsNone) _pos = position.Value;
				
				if (!x.IsNone) _pos.x = x.Value;
				if (!y.IsNone) _pos.y = y.Value;
				if (!z.IsNone) _pos.z = z.Value;
				
				rigidBody.position = _pos;
			}
		}

	}
}