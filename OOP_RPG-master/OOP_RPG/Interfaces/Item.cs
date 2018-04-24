using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_RPG.Actions;
using OOP_RPG.Characters;
using OOP_RPG.Equipment;

namespace OOP_RPG.Interfaces
{
    interface IItem //doesn't use access modifiers when creating, only use them when implementing
    {
        int OriginalValue { get; set; }
        int ResellValue { get; set; }
    }
}
