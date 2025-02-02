namespace RehvidGames.Animator
{
    using UnityEngine;
    
    public class RandomAnimationStateSelector : StateMachineBehaviour
    {
        [SerializeField] private int count;
        [SerializeField] private string parameterName;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            int newSelection = GetRandomSelection(animator);
            animator.SetInteger(parameterName, newSelection);
        }

        private int GetRandomSelection(Animator animator)
        {
            int randomSelection = GenerateRandomSelection();
            var currentSelection = animator.GetInteger(parameterName);
            
            if (count > 1)
            {
                randomSelection = EnsureDifferentSelection(randomSelection, currentSelection);
            }

            return randomSelection;
        }

        private int EnsureDifferentSelection(int selection, int currentSelection)
        {
            while (selection == currentSelection)
            {
                selection = GenerateRandomSelection();
            }

            return selection;
        }
        
        private int GenerateRandomSelection() => Random.Range(0, count);
    }
}