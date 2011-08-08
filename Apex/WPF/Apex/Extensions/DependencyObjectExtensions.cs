﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.ComponentModel;

#if !SILVERLIGHT
using System.Windows.Markup.Primitives;
#endif

namespace Apex.Extensions
{
  public static class DependencyObjectExtensions
  {
    public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
    {
      DependencyObject dependencyObject = VisualTreeHelper.GetParent(child);
      if (dependencyObject != null)
      {
        T parent = dependencyObject as T;
        if (parent != null)
        {
          return parent;
        }
        else
        {
          return GetParent<T>(dependencyObject);
        }
      }
      else
      {
        return null;
      }
    }

    public static DependencyObject GetTopLevelParent(this DependencyObject child)
    {
        DependencyObject tmp = child;
        DependencyObject parent = null;
        while ((tmp = VisualTreeHelper.GetParent(tmp)) != null)
        {
            parent = tmp;
        }
        return parent;
    }

    public static List<T> GetChildObjects<T>(this DependencyObject obj, string name)
    {
      var retVal = new List<T>();
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
      {
        object c = VisualTreeHelper.GetChild(obj, i);
        if ((c.GetType().FullName == typeof(T).FullName || c.GetType().IsSubclassOf(typeof(T))) && (String.IsNullOrEmpty(name) || ((FrameworkElement)c).Name == name))
        { 
          retVal.Add((T)c);
        }
        var gc = ((DependencyObject)c).GetChildObjects<T>(name);
        if (gc != null)
          retVal.AddRange(gc);
      }

      return retVal;
    }

    public static T GetChildObject<T>(this DependencyObject obj, string name) where T : DependencyObject
    {
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
      {
        object c = VisualTreeHelper.GetChild(obj, i);
        if (c.GetType().FullName == typeof(T).FullName && (String.IsNullOrEmpty(name) || ((FrameworkElement)c).Name == name))
        {
          return (T)c;
        }
        object gc = ((DependencyObject)c).GetChildObject<T>(name);
        if (gc != null)
          return (T)gc;
      }

      return null;
    }

    public static T FindChild<T>(this DependencyObject me, string childName) where T : DependencyObject
    {
      // Confirm parent and childName are valid. 
      if (me == null) return null;

      T foundChild = null;

      int childrenCount = VisualTreeHelper.GetChildrenCount(me);
      for (int i = 0; i < childrenCount; i++)
      {
        var child = VisualTreeHelper.GetChild(me, i);
        // If the child is not of the request child type child
        T childType = child as T;
        if (childType == null)
        {
          // recursively drill down the tree
          foundChild = FindChild<T>(child, childName);

          // If the child is found, break so we do not overwrite the found child. 
          if (foundChild != null) break;
        }
        else if (!string.IsNullOrEmpty(childName))
        {
          var frameworkElement = child as FrameworkElement;
          // If the child's name is set for search
          if (frameworkElement != null && frameworkElement.Name == childName)
          {
            // if the child's name is of the request name
            foundChild = (T)child;
            break;
          }
        }
        else
        {
          // child element found.
          foundChild = (T)child;
          break;
        }
      }

      return foundChild;
    }

#if !SILVERLIGHT

    public static List<Binding> GetBindingObjects(this DependencyObject me)
    {
      List<Binding> bindings = new List<Binding>();
      List<DependencyProperty> dpList = GetDependencyProperties(me);
      
      foreach (DependencyProperty dp in dpList)
      {
        Binding b = BindingOperations.GetBinding(me, dp);
        if (b != null)
        {
          bindings.Add(b);
        }
      }

      return bindings;
    }

    public static List<DependencyProperty> GetDependencyProperties(this DependencyObject me)
    {

      List<DependencyProperty> attached = new List<DependencyProperty>();

      foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(me,
          new Attribute[] { new PropertyFilterAttribute(PropertyFilterOptions.All) }))
      {
        DependencyPropertyDescriptor dpd =
            DependencyPropertyDescriptor.FromProperty(pd);

        if (dpd != null)
        {
          attached.Add(dpd.DependencyProperty);
        }
      }

      return attached;
    }
#endif
  }

}