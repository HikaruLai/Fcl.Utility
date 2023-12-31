﻿using System.Collections.Generic;

namespace Fcl.Utility
{
    public interface ITagGenWorker<T>
    {
        int Length();
        void SetTagList(IList<T> tList);
        void SetTag(int index, T tag);
        T this[int index] { get; set; }
        T this[string tagName] { get; set; }
    }
}
