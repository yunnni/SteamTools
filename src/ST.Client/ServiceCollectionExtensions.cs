﻿using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Application.Entities;
using System.Application.Repositories;
using System.Application.Repositories.Implementation;
using System.Application.Services;
using System.Application.Services.Implementation;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IGameAccountPlatformAuthenticatorRepository, GameAccountPlatformAuthenticatorRepository>();
            return services;
        }

        /// <summary>
        /// 添加 通用 Http 服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpService(this IServiceCollection services)
        {
            services.AddHttpClient(); // 添加 System.Net.Http.HttpClient / HttpClientFactory
            services.AddSingleton<IHttpService, HttpServiceImpl>();
            return services;
        }

        public static IServiceCollection TryAddUserManager(this IServiceCollection services)
        {
            services.TryAddAreaResource<Area>();
            services.TryAddSingleton<IUserManager, UserManager>();
            return services;
        }

        /// <summary>
        /// 添加 HttpProxy 代理服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpProxyService(this IServiceCollection services)
        {
            services.AddSingleton<IHttpProxyService, HttpProxyServiceImpl>();
            return services;
        }
    }
}