using IdeapadToolkit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.ViewModels
{
    public class MainViewModel
    {
        private readonly ILenovoPowerSettingsService _lenovoPowerSettingsService;

        public MainViewModel(ILenovoPowerSettingsService lenovoPowerSettingsService)
        {
            this._lenovoPowerSettingsService = lenovoPowerSettingsService;
        }
    }
}
