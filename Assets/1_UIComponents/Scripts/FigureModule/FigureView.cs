using UnityEngine;

namespace _1_UIComponents.FigureModule
{
    public class FigureView : MonoBehaviour
    {
        [SerializeField] private float _transitionMultiplier;
        [SerializeField] private float _scaleMultiplier;
        
        public void ChangeXPosition(float xPosition)
        {
            transform.position = new Vector3(xPosition * _transitionMultiplier, transform.position.y, transform.position.z);
        }
        
        public void ChangeYPosition(float yPosition)
        {
            transform.position = new Vector3(transform.position.x, yPosition * _transitionMultiplier, transform.position.z);
        }

        public void ChangeXScale(float xScale)
        {
            transform.localScale = new Vector3(xScale * _scaleMultiplier, transform.localScale.y, transform.localScale.z);
        }

        public void ChangeYScale(float yScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, yScale * _scaleMultiplier, transform.localScale.z);
        }
    }
}