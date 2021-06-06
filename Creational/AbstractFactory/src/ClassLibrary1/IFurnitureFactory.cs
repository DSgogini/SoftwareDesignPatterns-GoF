using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    interface IFurnitureFactory
    {
        IFurniture Create();
    }
}