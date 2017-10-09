using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApiIdSrv4withX509
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                // IS3 does not include the api name/audience - hence the extra scope check
                options.Filters.Add(new AuthorizeFilter(ScopePolicy.Create("api")));
            })
                .AddAuthorization();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5002";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api";
                    options.ApiSecret = "secret";

                    // this is only needed because IS3 does not include the API name in the JWT audience list
                    // so we disable UseIdentityServerAuthentication JWT audience check and rely upon
                    // scope validation to ensure we're only accepting tokens for the right API
                    options.LegacyAudienceValidation = true;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}