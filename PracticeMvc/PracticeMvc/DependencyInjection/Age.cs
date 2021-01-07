using PracticeMvc.Data;
using PracticeMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMvc.DependencyInjection
{
    public class Age : IAge
    {

        

        public string GetMyAge(DateTime dob)
        {
            var val = DateTime.Now.Subtract(dob);
            DateTime age = DateTime.MinValue + val;
            return string.Format("{0} years {1} months {2} days", age.Year - 1, age.Month - 1, age.Day - 1);
        }

    }
}
