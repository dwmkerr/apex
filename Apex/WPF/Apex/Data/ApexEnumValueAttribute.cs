namespace Apex.Data
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class ApexEnumValueAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ApexEnumValueAttribute"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public ApexEnumValueAttribute(string name)
    {
      Name = name;
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name
    {
      get;
      set;
    }
  }
}
