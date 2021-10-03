using ProjectForTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForTest.Service
{
    public interface IFilmSpecialist
    {
        Movie SuggestMovie();
    }
}
