using DAO.Group_1;
using DAO.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Repositories.Group_2;
using TravelAgency.Validators;
using TravelAgency.Validators.Interfaces;

namespace WebAPITravelAgency
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)        //konfiguracja serwisow w aplikacji
        {            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddCors();

            // Context
            services.AddDbContextFactory<DatabaseContext>(options => options.UseSqlServer("server=DESKTOP-9FN9TUU\\SQLEXPRESS; database=TravelAgency; Trusted_Connection=True; Connection Timeout=30"));

            // Repositories
            services.AddTransient<CruiseRepository>();
            services.AddTransient<CustomerRepository>();
            services.AddTransient<FleetRepository>();
            services.AddTransient<SkipperRepository>();

            services.AddTransient<CrewRepository>();
            services.AddTransient<OfferRepository>();
            services.AddTransient<OrderRepository>();


            // Validators
            services.AddTransient<ICruiseExist, ICruiseExistValidator>();
            services.AddTransient<ICustomerExist, ICustomerExistValidator>();
            services.AddTransient<IFleetExist, IFleetExistValidator>();
            services.AddTransient<ISkipperExist, ISkipperExistValidator>();
            services.AddTransient<ICrewExist, ICrewExistValidator>();
            services.AddTransient<IOfferExist, IOfferExistValidator>();
            services.AddTransient<IOrderExist, IOrderExistValidator>();

            services.AddTransient<ICollectionValidator, CollectionValidator>();
            services.AddTransient<INoDuplicates, NoDuplicatesValidator>();


            // Mapping
            // Cruise
            services.AddTransient<CruiseDao>();
            services.AddAutoMapper(typeof(CruiseProfile));

            // Customer
            services.AddTransient<CustomerDao>();
            services.AddAutoMapper(typeof(CustomerProfile));

            // Fleet
            services.AddTransient<FleetDao>();
            services.AddAutoMapper(typeof(FleetProfile));

            // Skipper
            services.AddTransient<SkipperDao>();
            services.AddAutoMapper(typeof(SkipperProfile));

            // Crew
            services.AddTransient<CrewDao>();
            services.AddAutoMapper(typeof(CrewProfile));

            // Offer
            services.AddTransient<OfferDao>();
            services.AddAutoMapper(typeof(OfferProfile));

            // Order
            services.AddTransient<OrderDao>();
            services.AddAutoMapper(typeof(OrderProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting(); // wskazywanie odpowiednich adresow - API

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin                
                .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
