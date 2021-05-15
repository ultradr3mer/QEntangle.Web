using System.ComponentModel.DataAnnotations;

namespace QEntangle.Web.Models
{
  public class PostChoiceData
  {
    #region Properties

    [Required(ErrorMessage = "Please enter a name")]
    [Display(Name = "Name")]
    [StringLength(500)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter a options")]
    [Display(Name = "Options")]
    [StringLength(500)]
    public string Options { get; set; }

    #endregion Properties
  }
}