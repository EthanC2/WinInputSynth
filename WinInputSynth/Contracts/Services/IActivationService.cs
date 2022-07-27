using System.Threading.Tasks;

namespace WinInputSynth.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
