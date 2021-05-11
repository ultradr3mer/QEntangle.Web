using System;

namespace QEntangle.Web.Data
{
  public class ChoiceData
  {
    #region Properties

    public string DefinitiveOption { get; set; }
    public Guid Id { get; internal set; }
    public string Name { get; set; }
    public string[] Options { get; set; }

    #endregion Properties
  }
}