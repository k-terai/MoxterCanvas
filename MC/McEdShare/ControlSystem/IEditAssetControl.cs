using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.ControlSystem
{
    public interface IEditAssetControl : IControl
    {
        AssetSystem.Asset Target { get; }
    }
}
