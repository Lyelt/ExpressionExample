using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionExample
{
    internal class MyExpression
    {
        public string ExpressionString { get; set; }

        public string ResultString { get; set; }

        public MyExpression(string expression, string result)
        {
            ExpressionString = expression;
            ResultString = result;
        }
    }
}
