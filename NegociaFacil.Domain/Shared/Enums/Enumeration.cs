using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Shared.Enums
{
    public abstract class Enumeration
    {
        public int Id { get; }
        public string Name { get; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;

        public static IEnumerable<TEnum> GetAll<TEnum>() where TEnum : Enumeration
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

            var fields = typeof(TEnum).GetFields(bindingFlags);
            return fields
                .Select(f => f.GetValue(null))
                .Cast<TEnum>()
                .Where(e => e.Id > 0);
        }

        public static TEnum From<TEnum>(int id) where TEnum : Enumeration
            => Get<TEnum>(item => item.Id == id);

        public static TEnum FromName<TEnum>(string name) where TEnum : Enumeration
            => Get<TEnum>(item => item.Name == name);

        protected static TEnum Get<TEnum>(Func<TEnum, bool> predicate) where TEnum : Enumeration
            => GetAll<TEnum>().FirstOrDefault(predicate);

        public static bool IsValid<TEnum>(int id) where TEnum : Enumeration
            => Get<TEnum>(item => item.Id == id) != null;
    }
}
