using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_wzorce_projektowe.Models
{
    public interface IReport //interfejs wspolny dla wszystkich produktow abstract factory
    {
        string GetSerializedContent();

    }
}
