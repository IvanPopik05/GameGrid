using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Element : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        
        private bool _isMove = true;
        private bool _isFree = true;
        private float _timeMotion;
        
        private Element _target;
        private Vector3 _targetPosition;
        public bool IsMove => _isMove;
        public bool IsFree => _isFree;
        public void Initialize(float timeMotion) => 
            _timeMotion = timeMotion;
        public void ChangeText() => 
            _textMeshPro.GetRandomWord();
        public void ChangeStateOfMove(bool isMove) => 
            _isMove = isMove;
        public void ChangeStateOfFree(bool isFree) => 
            _isFree = isFree;
        public TextMeshProUGUI GetTextMeshPro() => _textMeshPro;

        public void SetTarget(Element target)
        {
            _target = target;
            _targetPosition = target.transform.position;
        }
        private void Update()
        {
            if(!_target)
                return;
            
            transform.position = Vector3.Lerp(transform.position,_targetPosition,Time.deltaTime * _timeMotion);

        }
    }
}