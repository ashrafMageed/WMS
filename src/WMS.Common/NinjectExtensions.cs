using System;
using System.Collections.Generic;
using AutoMapper;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.BindingGenerators;
using Ninject.Syntax;

namespace WMS.Common
{
    public static class NinjectExtensions
    {
        public static void LoadMappingProfiles<T>(this IKernel kernel)
        {
            kernel.Bind(scan => scan.FromAssemblyContaining<T>().Select(type => type.IsSubclassOf(typeof(Profile))).BindWith<ProfileBindingGenerator>());
        }
    }


    public class ProfileBindingGenerator : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            yield return bindingRoot.Bind(typeof(Profile)).To(type);
        }
    }
}
