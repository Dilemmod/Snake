using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    interface ISpace
    {
        void SpaceFilling(int choice, bool gameOrNo);
        void Action();
    }
}
