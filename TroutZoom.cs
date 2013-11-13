// Type: TroutZoom.TroutZoom
// Assembly: TroutZoom, Version=1.1.0.0, Culture=neutral, PublicKeyToken=a84158465d51f68d
// MVID: 0632150E-6A81-4FF2-9663-7F701F6E69DE
// Assembly location: C:\Users\strost\Downloads\TroutZoom\TroutZoom.dll

using Microsoft.VisualStudio.Text.Editor;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using TroutZoom.Properties;

namespace TroutZoom
{
  public class TroutZoom
  {
    private IWpfTextView _view;
    private string _zoomPropertyName;
    private bool _bFirst;

    public TroutZoom(IWpfTextView view)
    {
      this._view = view;
      this._zoomPropertyName = TroutZoom.GetPropertyName<double>((Expression<Func<double>>) (() => Settings.Default.LastZoomLevel));
      this._bFirst = true;
      Settings.Default.PropertyChanged += new PropertyChangedEventHandler(this.Default_PropertyChanged);
      this._view.LayoutChanged += new EventHandler<TextViewLayoutChangedEventArgs>(this.LayoutChanged);
      this._view.ZoomLevelChanged += new EventHandler<ZoomLevelChangedEventArgs>(this.ZoomLevelChanged);
      this._view.Closed += new EventHandler(this.ViewClosed);
    }

    private void ViewClosed(object sender, EventArgs e)
    {
      this._view.LayoutChanged -= new EventHandler<TextViewLayoutChangedEventArgs>(this.LayoutChanged);
      this._view.ZoomLevelChanged -= new EventHandler<ZoomLevelChangedEventArgs>(this.ZoomLevelChanged);
      this._view.Closed -= new EventHandler(this.ViewClosed);
      Settings.Default.PropertyChanged -= new PropertyChangedEventHandler(this.Default_PropertyChanged);
      this._view = (IWpfTextView) null;
    }

    private void LayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
    {
      if (!this._bFirst)
        return;
      this._bFirst = false;
      this.SetZoomLevel(this._view);
    }

    private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.SetZoomLevel(this._view);
    }

    private bool SetZoomLevel(IWpfTextView _view)
    {
      try
      {
        if (!_view.IsClosed)
        {
          if (!this._bFirst)
          {
            if (_view.ZoomLevel != Settings.Default.LastZoomLevel)
            {
              if (Settings.Default.LastZoomLevel >= Settings.Default.MinZoomLevel)
              {
                if (Settings.Default.LastZoomLevel <= Settings.Default.MaxZoomLevel)
                {
                  _view.ZoomLevel = Settings.Default.LastZoomLevel;
                  return true;
                }
              }
            }
          }
        }
      }
      catch (NullReferenceException ex)
      {
      }
      return false;
    }

    private void ZoomLevelChanged(object sender, ZoomLevelChangedEventArgs e)
    {
      if (sender == this || Settings.Default.LastZoomLevel == e.NewZoomLevel)
        return;
      Settings.Default.LastZoomLevel = e.NewZoomLevel;
      Settings.Default.Save();
    }

    private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
    {
      return (propertyExpression.Body as MemberExpression).Member.Name;
    }
  }
}
