using Core.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class Extensions : IExtensions
    {
        public string LimitLength(string source, int maxLength)
        {
            if (source != null)
            {
                if (source.Length <= maxLength)
                {
                    return source;
                }
                return source.Substring(0, maxLength);
            }
            return source;
        }
    }
}
