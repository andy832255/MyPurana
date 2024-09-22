using System.Collections;
using System.Linq.Expressions;

namespace Cyh.Net.Data.PageUtils
{
    public class PageList<T> : IPageList<T>
    {
        class Page : IPage<T>
        {
            internal IEnumerable<T> m_items;
            public Page(IEnumerable<T> items, int pageIndex)
            {
                this.m_items = items;
                this.PageIndex = pageIndex;
            }

            public int PageIndex { get; set; }
            public IEnumerable<T> Items => this.m_items;

            IEnumerable IPage.Items => this.Items;

            public IEnumerator<T> GetEnumerator() => this.m_items.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.m_items.GetEnumerator();
        }
        class PageEnumerator : IEnumerator<IPage<T>>
        {
            int m_currentIndex = -1;
            PageList<T> m_parent;
            public PageEnumerator(PageList<T> parent)
            {
                this.m_parent = parent;
            }

            int MaxPageCount()
            {
                return this.m_parent.PageCount;
            }
            public IPage<T> Current
            {
                get
                {
                    if (this.m_currentIndex == -1)
                    {
                        return new Page(Enumerable.Empty<T>(), -1);
                    }
                    return this.m_parent[this.m_currentIndex];
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++this.m_currentIndex < this.MaxPageCount();
            }

            public void Reset()
            {
                this.m_currentIndex = -1;
            }
        }

        readonly IQueryable<T> m_source;
        readonly Expression<Func<T, bool>> m_predicate;
        IEnumerable<T> m_items;
        public IPage<T> this[int page]
        {
            get
            {
                return new Page(
                    this.m_items
                    .Skip(page * this.PageSize)
                    .Take(this.PageSize).ToList(),
                    page);
            }
        }

        public PageList(IQueryable<T> source, Expression<Func<T, bool>> predicate, int pageSize = 10)
        {
            this.m_source = source;
            this.m_predicate = predicate;
            this.PageSize = pageSize;
            this.m_items = this.m_source.Where(predicate).AsEnumerable();
        }

        public void OrderBy<TKey>(Func<T, TKey> func, int direction)
        {
            if (direction >= 0)
            {
                this.m_items = this.m_items.OrderBy(func);
            }
            else
            {
                this.m_items = this.m_items.OrderByDescending(func);
            }
        }

        public int PageCount
        {
            get
            {
                int totalCount = this.TotalCount;
                int result = totalCount / this.PageSize;
                if (totalCount != result * this.PageSize)
                {
                    return result + 1;
                }
                return result;
            }
        }

        public int PageSize { get; set; }

        public int TotalCount => this.m_source.Count(this.m_predicate);

        public IEnumerable<IPage<T>> Pages => this;

        IEnumerable<IPage> IPageList.Pages => this;

        public IEnumerator<IPage> GetEnumerator()
        {
            return new PageEnumerator(this);
        }

        IEnumerator<IPage<T>> IEnumerable<IPage<T>>.GetEnumerator()
        {
            return new PageEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PageEnumerator(this);
        }
    }
}
