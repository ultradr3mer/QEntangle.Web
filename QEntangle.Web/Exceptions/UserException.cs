using System;

namespace QEntangle.Web.Exceptions
{
  public class UserException : Exception
  {
    #region Constructors

    public UserException(string message) : base(message)
    {
    }

    #endregion Constructors
  }
}