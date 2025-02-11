namespace RehvidGames.Characters.Player.States
{
    using Animator;
    using Enums;
    using RehvidGames.States;
    using UnityEngine;

    public class PlayerDeathState: BaseState<PlayerState>
    {
        private readonly Player player;

        private bool hasDeathAnimationTriggered;
        private bool hasColliderBeenDisabled;
        
        public PlayerDeathState(Player player) : base(PlayerState.Death)
        {
            this.player = player;
        }

        public override void EnterState()
        {
            player.Animator?.SetBool(CharacterAnimatorParameters.IsDeath, true);
            player.Animator?.SetTrigger(CharacterAnimatorParameters.Death);
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();

            if (!hasDeathAnimationTriggered) return;
            
            if (!hasColliderBeenDisabled)
            {
                DisableCollider();
                hasColliderBeenDisabled = true;
            }
            
            if (player.HasHitGround)
            {
                SetPlayerToKinematic();
            }

        }

        private void DisableCollider()
        {
            CapsuleCollider2D capsuleCollider2D = player.GetCapsuleCollider();
            if (capsuleCollider2D != null)
            {
                capsuleCollider2D.enabled = false;
            }
        }
        
        private void SetPlayerToKinematic()
        {
            player.PhysicsController.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            player.PhysicsController.SetLinearVelocity(Vector2.zero);
        }

        public override void AnimationTriggerEvent(AnimationTriggerType triggerType)
        { 
            if (triggerType == AnimationTriggerType.Death)
            {
                hasDeathAnimationTriggered = true;
            }
        }
    }
}