using System.Linq.Expressions;
using System.Reflection;

namespace Cyh.Net.Data.Expressions
{
    public interface IExpressionMakerGenerator<T>
    {
    }
    public interface IExpressionMaker<T>
    {
        public LinkType LinkType { get; set; }
        Expression<Func<T, bool>> GetExpression();
    }
    public interface IParamRequiredExpressionMaker<T, TKey>
    {
        IExpressionMaker<T> GetExpressionMakerContains(IEnumerable<TKey> _datas);
        IExpressionMaker<T> GetExpressionMaker(TKey data);
    }
    public interface IMemberNameRequiredExpressionMaker<T>
    {
        IExpressionMaker<T> GetExpressionMakerContains<TKey>(string memberName, IEnumerable<TKey> _datas);
        IExpressionMaker<T> GetExpressionMaker<TKey>(string memberName, CompareType compareType, TKey _data);
    }
    internal class ImplExpressionMaker<T> : IExpressionMaker<T>
    {
        private Expression<Func<T, bool>> Expression { get; set; }
        private CompareType CompareType { get; set; }
        public ImplExpressionMaker(LinkType linkType, Expression<Func<T, bool>> expression)
        {
            this.Expression = expression;
            this.LinkType = linkType;
        }
        public LinkType LinkType { get; set; }
        public Func<T, bool> GetDelegate()
        {
            return this.Expression.Compile();
        }
        public Expression<Func<T, bool>> GetExpression()
        {
            return this.Expression;
        }
    }
    internal class ImplParamRequiredExpressionMaker<T, TKey> : IParamRequiredExpressionMaker<T, TKey>
    {
        static ImplParamRequiredExpressionMaker()
        {
            ComparableTKey = typeof(IComparable<TKey>);
            Comparable = typeof(IComparable);
            EquatableTKey = typeof(IEquatable<TKey>);
            KeyType = typeof(TKey);
            KeyIsComparable = KeyType.GetInterfaces().Contains(Comparable);
            KeyIsComparable_ = KeyType.GetInterfaces().Contains(ComparableTKey);
            KeyIsEquatable_ = KeyType.GetInterfaces().Contains(EquatableTKey);
        }
        private static Type ExtType => typeof(Extensions);
        private static Type ComparableTKey;
        private static Type Comparable;
        private static Type EquatableTKey;
        private static Type KeyType;
        private static bool KeyIsComparable;
        private static bool KeyIsComparable_;
        private static bool KeyIsEquatable_;
        private Func<T, bool> MakeDelegate(TKey data)
        {
            return this.MakeExpression(data).Compile();
        }
        private Expression<Func<T, bool>> MakeExpressionContains(IEnumerable<TKey> _data)
        {
            return t => this.GetCompareKey(t).IsAnyOf(_data);
        }
        private Expression<Func<T, bool>> MakeExpression(TKey _data)
        {
            IComparable<TKey>? comparable = null;
            IEquatable<TKey>? equatable = null;
            string? _str = null;
            try
            {
                comparable = (IComparable<TKey>?)_data;
            }
            catch { }
            try
            {
                equatable = (IEquatable<TKey>?)_data;
            }
            catch { }
            try
            {
                _str = _data?.ToString();
            }
            catch { }

#pragma warning disable CS8602, CS8604
            switch (this.CompareType)
            {
                case CompareType.Equal:
                case CompareType.NotEqual:
                    return Extensions.MakeExpressionEquatable(this.GetCompareKey, this.CompareType, equatable);
                case CompareType.GreaterThan:
                case CompareType.GreaterThanOrEqual:
                case CompareType.LessThan:
                case CompareType.LessThanOrEqual:
                    return Extensions.MakeExpressionComparable(this.GetCompareKey, this.CompareType, comparable);
                case CompareType.Contains:
                {
                    if (KeyType == typeof(string))
                    {
                        return t => this.GetCompareKey(t).ToString().Contains(_str);
                    }
                    break;
                }
                default:
                    break;
            }
#pragma warning restore CS8602, CS8604
            return t => true;
        }
        private Func<T, TKey> GetCompareKey { get; set; }
        private CompareType CompareType { get; set; }
        private LinkType LinkType { get; set; }
        public ImplParamRequiredExpressionMaker(LinkType linkType, CompareType compareType, Func<T, TKey> delegateGetCompareKey)
        {
            this.CompareType = compareType;
            this.LinkType = linkType;
            this.GetCompareKey = delegateGetCompareKey;
        }
        public IExpressionMaker<T> GetExpressionMakerContains(IEnumerable<TKey> _datas)
        {
            return new ImplExpressionMaker<T>(this.LinkType, this.MakeExpressionContains(_datas));
        }
        public IExpressionMaker<T> GetExpressionMaker(TKey data)
        {
            return new ImplExpressionMaker<T>(this.LinkType, this.MakeExpression(data));
        }
    }
    internal class ImplMemberNameRequiredExpressionMaker<T> : IMemberNameRequiredExpressionMaker<T>
    {
        private static Expression<Func<T, bool>> MakeExpression_Contains(Func<T, string> keySelector, string _data)
        {
            return t => keySelector(t).Contains(_data);
        }
        private static Expression<Func<T, bool>> MakeExpression_Contains<TKey>(Func<T, TKey> keySelector, IEnumerable<TKey> _data)
        {
            return t => keySelector(t).IsAnyOf(_data);
        }
        private static Type InstanceType => typeof(T);
        private static Expression<Func<T, bool>> MakeContainsExpression<TKey>(string memberName, IEnumerable<TKey> _datas)
        {
            PropertyInfo? memberProperty = typeof(T).GetProperty(memberName);
#pragma warning disable CS8602, CS8604
            return MakeExpression_Contains(
                (Func<T, TKey>)Delegate.CreateDelegate(typeof(Func<T, TKey>), memberProperty.GetGetMethod()),
                _datas);
#pragma warning restore CS8602, CS8604
        }
        private static Expression<Func<T, bool>> MakeExpression<TKey>(string memberName, CompareType compareType, TKey _data)
        {
            PropertyInfo? memberProperty = typeof(T).GetProperty(memberName);
            if (compareType == CompareType.Contains)
            {
#pragma warning disable CS8602, CS8604
                return MakeExpression_Contains(
                    (Func<T, string>)Delegate.CreateDelegate(typeof(Func<T, string>), memberProperty.GetGetMethod()),
                    _data.ToString());
#pragma warning restore CS8602, CS8604
            }

            ParameterExpression parameter = Expression.Parameter(InstanceType, "x");
            ConstantExpression constant = Expression.Constant(_data);
#pragma warning disable CS8600, CS8602, CS8604
            MemberExpression member = Expression.Property(parameter, typeof(T).GetProperty(memberName));
            BinaryExpression body = null;

            switch (compareType)
            {
                case CompareType.Equal:
                    body = Expression.Equal(member, constant);
                    break;
                case CompareType.NotEqual:
                    body = Expression.NotEqual(member, constant);
                    break;
                case CompareType.GreaterThan:
                    body = Expression.GreaterThan(member, constant);
                    break;
                case CompareType.GreaterThanOrEqual:
                    body = Expression.GreaterThanOrEqual(member, constant);
                    break;
                case CompareType.LessThan:
                    body = Expression.LessThan(member, constant);
                    break;
                case CompareType.LessThanOrEqual:
                    body = Expression.LessThanOrEqual(member, constant);
                    break;
                default:
                    break;
            }
            return Expression.Lambda<Func<T, bool>>(body, parameter);
#pragma warning restore CS8600, CS8602, CS8604
        }
        private LinkType LinkType { get; set; }
        public ImplMemberNameRequiredExpressionMaker(LinkType linkType)
        {
            this.LinkType = linkType;
        }
        public IExpressionMaker<T> GetExpressionMakerContains<TKey>(string memberName, IEnumerable<TKey> _datas)
        {
            return new ImplExpressionMaker<T>(this.LinkType, MakeContainsExpression(memberName, _datas));
        }
        public IExpressionMaker<T> GetExpressionMaker<TKey>(string memberName, CompareType compareType, TKey _data)
        {
            return new ImplExpressionMaker<T>(this.LinkType, MakeExpression(memberName, compareType, _data));
        }
    }

    public class ExpressionMaker
    {
        public static IExpressionMaker<T> GetExpressionMaker<T>(LinkType linkType, Expression<Func<T, bool>> expression)
        {
            return new ImplExpressionMaker<T>(linkType, expression);
        }
        public static IParamRequiredExpressionMaker<T, TKey> GetExpressionMaker<T, TKey>(LinkType linkType, CompareType compareType, Func<T, TKey> delegateGetCompareKey)
        {
            return new ImplParamRequiredExpressionMaker<T, TKey>(linkType, compareType, delegateGetCompareKey);
        }
        public static IMemberNameRequiredExpressionMaker<T> GetExpressionMaker<T>(LinkType linkType)
        {
            return new ImplMemberNameRequiredExpressionMaker<T>(linkType);
        }
    }

    public static partial class Extensions
    {
        internal static Expression<Func<T, bool>> MakeExpressionComparable<T, TKey>(Func<T, TKey> keySelector, CompareType compareType, IComparable<TKey> _data)
        {
            switch (compareType)
            {
                case CompareType.LessThan:
                    return t => _data.CompareTo(keySelector(t)) > 0;
                case CompareType.LessThanOrEqual:
                    return t => _data.CompareTo(keySelector(t)) >= 0;
                case CompareType.GreaterThan:
                    return t => _data.CompareTo(keySelector(t)) < 0;
                case CompareType.GreaterThanOrEqual:
                    return t => _data.CompareTo(keySelector(t)) <= 0;
                default:
                    return t => true;
            }
        }
        internal static Expression<Func<T, bool>> MakeExpressionEquatable<T, TKey>(Func<T, TKey> keySelector, CompareType compareType, IEquatable<TKey> _data)
        {
            switch (compareType)
            {
                case CompareType.Equal:
                    return t => _data.Equals(keySelector(t));
                case CompareType.NotEqual:
                    return t => !_data.Equals(keySelector(t));
                default:
                    return t => true;
            }
        }
        public static Expression<Func<T, bool>> MakeExpression<T>(this IEnumerable<IExpressionMaker<T>> queryDatas)
        {
            if (queryDatas.Count() == 0) return (t) => true;
            Expression<Func<T, bool>> expression;
            IEnumerator<IExpressionMaker<T>> iterator = queryDatas.GetEnumerator();
            iterator.MoveNext();
            expression = iterator.Current.GetExpression();
            while (iterator.MoveNext())
            {
                expression = iterator.Current.LinkType == LinkType.And
                    ? expression.UpdateExpression(iterator.Current.GetExpression(), true)
                    : expression.UpdateExpression(iterator.Current.GetExpression(), false);
            }
            return expression;
        }

        public static IExpressionMaker<T> GetExpressionMakerContains<T, TKey>(this IExpressionMakerGenerator<T> self, LinkType linkType, Func<T, TKey> expressionGetParameterV, IEnumerable<TKey> values)
        {
            return ExpressionMaker.GetExpressionMaker(linkType, CompareType.Contains, expressionGetParameterV).GetExpressionMakerContains(values);
        }

        public static IExpressionMaker<T> GetExpressionMaker<T, TKey>(this IExpressionMakerGenerator<T> self, LinkType linkType, Func<T, TKey> expressionGetParameterV, CompareType compareType, TKey value)
        {
            return ExpressionMaker.GetExpressionMaker(linkType, compareType, expressionGetParameterV).GetExpressionMaker(value);
        }

        public static IExpressionMaker<T> GetExpressionMaker<T>(this IExpressionMakerGenerator<T> self, LinkType linkType, Expression<Func<T, bool>> expression)
        {
            return ExpressionMaker.GetExpressionMaker(linkType, expression);
        }
    }
}
