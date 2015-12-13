using System;

namespace _S_LibraryProjectName_S_.Module.Common.Services
{
    public interface IKeepAliveService: IDisposable
    {
        void Activate();
        bool KeepAlive();
        void Release();
    }
}