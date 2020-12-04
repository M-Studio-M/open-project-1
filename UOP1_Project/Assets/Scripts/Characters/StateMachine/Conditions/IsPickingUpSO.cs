﻿using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Picking Up")]
public class IsPickingUpSO : StateConditionSO<IsPickingUpCondition> { }

public class IsPickingUpCondition : Condition
{
	//Component references
	private InteractionManager _interactScript;

	public override void Awake(StateMachine stateMachine)
	{
		_interactScript = stateMachine.GetComponentInChildren<InteractionManager>();
	}

	protected override bool Statement()
	{
		if (_interactScript.currentInteraction == Interaction.PickUp)
		{
			// Consume the input
			_interactScript.currentInteraction = Interaction.None;

			return true;
		}
		else
		{
			return false;
		}
	}
}
