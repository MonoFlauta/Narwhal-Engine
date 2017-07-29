using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluteEngine.Managers.Complements
{
    interface IScreen
    {
        void Open();
        void Update(float deltaTime);
        void Exit();
    }
}
