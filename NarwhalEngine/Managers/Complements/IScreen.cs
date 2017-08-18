using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarwhalEngine.Managers.Complements
{
    interface IScreen
    {
        void Open();
        void Update(float deltaTime);
        void Exit();
    }
}
