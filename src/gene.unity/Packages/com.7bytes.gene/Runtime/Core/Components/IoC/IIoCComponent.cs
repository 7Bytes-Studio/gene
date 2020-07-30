using System;

namespace Gene.Runtime
{
    public interface IIoCComponent
    {
        void LoadConfig(IoCConfig config);

        object Use(Type tp);
        
        void Build();
    }
}