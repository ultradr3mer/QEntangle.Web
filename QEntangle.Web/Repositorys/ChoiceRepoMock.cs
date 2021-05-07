using QEntangle.Web.Data;
using QEntangle.Web.Interfaces;
using System.Collections.Generic;

namespace QEntangle.Web.Repositorys
{
  public class ChoiceRepoMock : IChoiceRepository
  {
    #region Methods

    public IList<ChoiceData> GetChoices()
    {
      return new List<ChoiceData> {
        new ChoiceData { Name = "Which Energydrink", Options = "Original,Watermellon", DefinitiveOption = "Watermellon" },
        new ChoiceData { Name = "Eat Cookie", Options = "Yes,No", DefinitiveOption = "No" }
      };
    }

    #endregion Methods
  }
}