// -----------------------------------------------------------------------
// <copyright file="ExampleEnumeration.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ControlsSample
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  using Apex.Data;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public enum ExampleEnumeration
  {
    /// <summary>
    /// 
    /// </summary>
    
    [ApexEnumValue("Microsoft SQL Server")]
    SQLServer,

    [ApexEnumValue("Oracle")]
    Oracle
  }
}
