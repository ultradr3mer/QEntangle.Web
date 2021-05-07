using QEntangle.Web.Data;
using System.Collections.Generic;

namespace QEntangle.Web.Interfaces
{
  public interface IChoiceRepository
  {
    #region Methods

    public IList<ChoiceData> GetChoices();

    #endregion Methods
  }
}