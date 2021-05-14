using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsShowcase.Models
{
    public abstract class ViewModelBase
    {
    }

    public class NavBarModel : ViewModelBase
    {
        public string active = "";
    }
}
