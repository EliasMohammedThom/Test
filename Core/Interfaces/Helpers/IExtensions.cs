using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Helpers
{
    public interface IExtensions
    {
        public string LimitLength(string source, int maxLength);
    }
}
