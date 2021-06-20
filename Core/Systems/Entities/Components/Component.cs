using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NakaEngine.Core.Systems.Entities.Components
{
    public class Component
    {
        public GameObject GameObject;

        public Behaviour Behaviour => GameObject.GetComponent<Behaviour>();

        public Transform Transform => GameObject.GetComponent<Transform>();

        public Sprite Sprite => GameObject.GetComponent<Sprite>();

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
