using System;
using System.Collections.Generic;
using System.Text;

namespace Errpg.Support
{
    public interface ILogger
    {
        void Write(string message);
        void Write(Exception exception);
    }
}
