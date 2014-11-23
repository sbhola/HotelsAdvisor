using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutocompleteData
{
    interface IAutocompleteDataProvider
    {
        AutocompleteSearchObject[] getMatchingData(string input);
    }
}
