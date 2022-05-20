using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSender : MonoBehaviour
{
    KnightCharacterController _charController;

    private void Start()
    {
        _charController = GetComponentInParent<KnightCharacterController>();
    }

    public void OnFootstep(AnimationEvent animationEvent)
    {
        _charController.OnFootstep(animationEvent); //TODO fix animatio event sender in animclip
    }

    public void OnLand(AnimationEvent animationEvent)
    {
        _charController.OnLand(animationEvent);
    }
}
