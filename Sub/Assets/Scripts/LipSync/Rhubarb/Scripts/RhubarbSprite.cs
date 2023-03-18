using UnityEngine;

namespace FriendlyMonster.RhubarbTimeline
{
    //[RequireComponent(typeof(Material))]
    
    public class RhubarbSprite : MonoBehaviour
    {
        [SerializeField] Material mat;
        [SerializeField] private RhubarbSpriteSet _rhubarbSpriteSet;

        public RhubarbSpriteSet RhubarbSpriteSet
        {
            get { return _rhubarbSpriteSet; }
            set { _rhubarbSpriteSet = value; }
        }
        public MouthShape MouthShape
        {
            set
            {
                    if (mat == null)
                    {
                        mat = GetComponent<Material>();
                    }
                    mat.mainTexture = _rhubarbSpriteSet.GetSprite(value);
            }
        }
    }
}