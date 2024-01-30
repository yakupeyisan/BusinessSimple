using System;
using System.Net.Http;

namespace Business.Tools.Exceptions;

public class ValidationException:Exception
{
	public short StatusCode; 
	public ValidationException(string message,short statusCode=400):base(message)
	{
		StatusCode = statusCode;
	}
}
