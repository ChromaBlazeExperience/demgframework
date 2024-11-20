using UnityEngine;

namespace DemGFramework.Shared.Components
{
    public class RBFPSMovementManager
    {
        new Transform transform;
        new Rigidbody rigidbody;

        float speed = 6.5f;
        float acceleration = 70f;
        float multiplier = 10f;
        float maxVelocity = 450f;

        bool alignControllerToGround = false;
        float alignToGroundSmooth;

        //todo: use autogravity


        public void Update()
        {

        }

    }
}