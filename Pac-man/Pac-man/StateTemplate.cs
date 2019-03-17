using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
   public abstract class StateTemplate
    {
        abstract public void Draw();
        public abstract void Update(GameTime gameTime);
    }

}
