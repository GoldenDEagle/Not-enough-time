using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InteractionSystem
{
    public interface IInteractable
    {
        // displyed in UI near object
        public string InteractionPrompt { get; }

        // returns true if succeeded
        public bool Interact();
    }
}
