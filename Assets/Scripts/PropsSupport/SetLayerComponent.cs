using UnityEngine;

namespace Assets.Scripts.PropsSupport
{
    public class SetLayerComponent : MonoBehaviour
    {
        public void SetLayer(int layerNumber)
        {
            gameObject.layer = layerNumber;
        }
    }
}