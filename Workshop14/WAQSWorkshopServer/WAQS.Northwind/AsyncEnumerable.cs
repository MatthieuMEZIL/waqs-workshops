//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 

namespace WAQS.DAL.Interfaces
{
    public class AsyncEnumerable : IAsyncEnumerable
    {
        private IAsyncEnumerator _asyncEnumerator;
    
        public AsyncEnumerable(IAsyncEnumerator asyncEnumerator)
        {
            _asyncEnumerator = asyncEnumerator;
        }
    
        public IAsyncEnumerator GetAsyncEnumerator()
        {
            return _asyncEnumerator;
        }
    }
    
    public class AsyncEnumerable<T> : AsyncEnumerable, IAsyncEnumerable<T>
    {
        private IAsyncEnumerator<T> _asyncEnumerator;
    
        public AsyncEnumerable(IAsyncEnumerator<T> asyncEnumerator)
            : base(asyncEnumerator)
        {
            _asyncEnumerator = asyncEnumerator;
        }
    
        public new IAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return _asyncEnumerator;
        }
    }
}
