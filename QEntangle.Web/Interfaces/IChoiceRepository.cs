using QEntangle.Web.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QEntangle.Web.Interfaces
{
  public interface IChoiceRepository
  {
    #region Methods

    public Task<IList<ChoiceData>> GetChoices();

    #endregion Methods
  }
}