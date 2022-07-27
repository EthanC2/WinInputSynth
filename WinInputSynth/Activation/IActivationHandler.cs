using System.Threading.Tasks;

namespace WinInputSynth.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);
    Task HandleAsync(object args);
}
