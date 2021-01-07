using PracticeMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMvc.DependencyInjection
{
    public interface IAge
    {
        string GetMyAge(DateTime dob);


    }
}
