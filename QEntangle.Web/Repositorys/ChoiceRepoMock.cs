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
        new ChoiceData { Name = "Which Energydrink", Options = new string[] { "Original","Watermellon" }, DefinitiveOption = "Watermellon" },
        new ChoiceData { Name = "Eat Cookie", Options = new string[] {"Yes","No" }, DefinitiveOption = "No" },
        new ChoiceData { Name = "Go Walk", Options = new string[] {"Yes","No" }, DefinitiveOption = "No" },
        new ChoiceData { Name = "Take oportunity", Options = new string[] {"A","B","C" }, DefinitiveOption = "B" },
        new ChoiceData { Name = "Go on trip", Options = new string[] {"Yes","No" }, DefinitiveOption = "No" },
        new ChoiceData { Name = "Which Energydrink", Options = new string[] {"Original","Watermellon" }, DefinitiveOption = "Watermellon" },
        new ChoiceData { Name = "Eat Cookie", Options = new string[] {"Yes","No" }, DefinitiveOption = "No" },
        new ChoiceData { Name = "Go Walk", Options = new string[] {"Yes","No" }, DefinitiveOption = "No" },
        new ChoiceData { Name = "Take oportunity", Options = new string[] {"A","B","C" }, DefinitiveOption = "C" },
        new ChoiceData { Name = "Go on trip", Options = new string[] {"Yes","No" }, DefinitiveOption = "No" }
      };
    }

    #endregion Methods
  }
}