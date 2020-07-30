using System;

namespace Gene.Runtime
{
    public class IoCBinding
    {
        internal Type absType;
        internal Type implType;
        
        public IoCBinding(Type absType,Type implType)
        {
            this.absType = absType;
            this.implType = implType;
        }
    }

    public class IoCBinding<TAbs, TImpl> : IoCBinding
    {
        public IoCBinding() : base(typeof(TAbs), typeof(TImpl))
        {
        }
    }
    
}