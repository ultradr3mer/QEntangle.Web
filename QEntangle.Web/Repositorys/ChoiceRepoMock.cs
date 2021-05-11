using QEntangle.Web.Data;
using QEntangle.Web.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QEntangle.Web.Repositorys
{
  public class ChoiceRepoMock : IChoiceRepository
  {
    #region Methods

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IList<ChoiceData>> GetChoices()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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