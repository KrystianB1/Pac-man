using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
    abstract class StateTemplate
    {
        abstract public void Update(GameTime gameTime);
        abstract public void Draw();
    }
}
