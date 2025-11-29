using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Interfaces
{
    internal interface IDeletable
    {
        bool DeleteById(int id);
    }
}
