using QEntangle.Web.Composite;
using QEntangle.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QEntangle.Web.ViewModels
{
  public class ChoicesListViewModel
  {
    #region Properties

    public IList<ChoiceEntryViewModel> Evaluated { get; set; }
    public IList<ChoiceEntryViewModel> Unevaluated { get; set; }

    #endregion Properties

    #region Classes

    public class ChoiceEntryViewModel : BaseViewModel<ChoiceData>
    {
      #region Properties

      public Guid Id { get; set; }
      public bool IsExecuteEnabled { get; set; } = true;
      public string Name { get; set; }
      public List<OptionViewModel> Options { get; set; }

      #endregion Properties

      #region Methods

      protected override void OnReadingDataModel(ChoiceData data)
      {
        var options = data.Options.Select(o =>
        {
          OptionViewModel vm = new OptionViewModel(o)
          {
            IsDefinitive = o == data.DefinitiveOption
          };
          return vm;
        }).ToList();

        this.Options = options;
      }

      #endregion Methods
    }

    public class OptionViewModel : BaseViewModel
    {
      #region Constructors

      public OptionViewModel(string name)
      {
        this.Name = name;
      }

      #endregion Constructors

      #region Properties

      public bool IsDefinitive { get; set; }
      public string Name { get; set; }

      #endregion Properties
    }

    #endregion Classes
  }
}