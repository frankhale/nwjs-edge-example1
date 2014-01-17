using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary
{
    public class HelloWorld
    {
			public async Task<object> SayHello(object input)
			{
				return await Task.FromResult<string>(string.Format("Hello {0} From C#", input));
			}
    }
}
