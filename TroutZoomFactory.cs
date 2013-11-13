// Type: TroutZoom.TroutZoomFactory
// Assembly: TroutZoom, Version=1.1.0.0, Culture=neutral, PublicKeyToken=a84158465d51f68d
// MVID: 0632150E-6A81-4FF2-9663-7F701F6E69DE
// Assembly location: C:\Users\strost\Downloads\TroutZoom\TroutZoom.dll

using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace TroutZoom
{
  [TextViewRole("DOCUMENT")]
  [Export(typeof (IWpfTextViewCreationListener))]
  [ContentType("text")]
  internal sealed class TroutZoomFactory : IWpfTextViewCreationListener
  {
    public void TextViewCreated(IWpfTextView textView)
    {
      TroutZoom troutZoom = new TroutZoom(textView);
    }
  }
}
