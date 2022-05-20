using System.Collections;
using UnityEngine;

    public class GameSystem : StateMachine
    {
        [SerializeField] private HealthManager ui;

        public HealthManager Interface => ui;

        private void Start()
        {  
            SetState(new Begin(this));

        }

        public void OnAttackButton()
        {
            StartCoroutine(State.Attack());
        }

}