using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoProject
{
    public interface IAutomationExecute
    {
        void Execute();
        void Teardown();
    }
}
