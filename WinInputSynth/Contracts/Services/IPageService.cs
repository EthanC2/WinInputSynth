using System;
using System.Collections.Generic;

namespace WinInputSynth.Contracts.Services;

public interface IPageService
{
    bool PageExists(Type page);
}
