using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace SilverlightSelectionBug
{
    [ViewModel]
    public class FruitPageGroupViewModel : PageViewModel
    {
        public FruitPageGroupViewModel()
        {
            Title = "Fruit";
        }
    }

    [ViewModel]
    public class ApplePageViewModel : PageViewModel
    {
        public ApplePageViewModel()
        {
            Title = "Apple";
        }
    }

    [ViewModel]
    public class PearPageViewModel : PageViewModel
    {
        public PearPageViewModel()
        {
            Title = "Pear";
        }
    }

    [ViewModel]
    public class VegPageGroupViewModel : PageViewModel
    {
        public VegPageGroupViewModel()
        {
            Title = "Veg";
        }
    }

    [ViewModel]
    public class OnionPageViewModel : PageViewModel
    {
        public OnionPageViewModel()
        {
            Title = "Onion";
        }
    }

    [ViewModel]
    public class CarrotPageViewModel : PageViewModel
    {
        public CarrotPageViewModel()
        {
            Title = "Carrot";
        }
    }
}
