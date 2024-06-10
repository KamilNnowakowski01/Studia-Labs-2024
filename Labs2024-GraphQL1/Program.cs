using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Labs2024_Application.Mapping;
using Labs2024_Application.Services;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;
using Labs2024_Infrastructure;
using Labs2024_Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Labs2024_GraphQL
{
    /*
    public record Employee(int Id, string Name, int Age, int DeptId);

    public record Department(int Id, string Name);

    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DeptName { get; set; }
    }

    public class EmployeeDetailsType : ObjectGraphType<EmployeeDetails>
    {
        public EmployeeDetailsType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Age);
            Field(x => x.DeptName);
        }
    }

    public interface IEmployeeService
    {
        public List<EmployeeDetails> GetEmployees();

        public List<EmployeeDetails> GetEmployee(int empId);

        public List<EmployeeDetails> GetEmployeesByDepartment(int deptId);
    }

    public class EmployeeService : IEmployeeService
    {
        public EmployeeService()
        {

        }
        private List<Employee> employees = new List<Employee>
        {
            new Employee(1, "Tom", 25, 1),
            new Employee(2, "Henry", 28, 1),
            new Employee(3, "Steve", 30, 2),
            new Employee(4, "Ben", 26, 2),
            new Employee(5, "John", 35, 3),

        };

        private List<Department> departments = new List<Department>
        {
            new Department(1, "IT"),
            new Department(2, "Finance"),
            new Department(3, "HR"),
        };

        public List<EmployeeDetails> GetEmployees()
        {
            return employees.Select(emp => new EmployeeDetails
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                DeptName = departments.First(d => d.Id == emp.DeptId).Name,
            }).ToList();

        }
        public List<EmployeeDetails> GetEmployee(int empId)
        {
            return employees.Where(emp => emp.Id == empId).Select(emp => new EmployeeDetails
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                DeptName = departments.First(d => d.Id == emp.DeptId).Name,
            }).ToList();
        }

        public List<EmployeeDetails> GetEmployeesByDepartment(int deptId)
        {
            return employees.Where(emp => emp.DeptId == deptId).Select(emp => new EmployeeDetails
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                DeptName = departments.First(d => d.Id == deptId).Name,
            }).ToList();
        }
    }

    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService employeeService)
        {
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employees", resolve: x => employeeService.GetEmployees());
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: x => employeeService.GetEmployee(x.GetArgument<int>("id")));
        }
    }

    public class EmployeeDetailsSchema : Schema
    {
        public EmployeeDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<EmployeeQuery>();
        }
    }
    */

    //public record Car(int ID, string Brand, string Model, int YearOfProduction, string CarRegistration);

    public class CarDetails {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public string CarRegistration { get; set; }
    }

    public class CarDetailsType : ObjectGraphType<CarDetails>
    {
        public CarDetailsType()
        {
            Field(x => x.ID);
            Field(x => x.Brand);
            Field(x => x.Model);
            Field(x => x.YearOfProduction);
            Field(x => x.CarRegistration);
        }
    }

    public interface ICarServiceAdapter
    {
        public List<CarDetails> GetAllCarDetails();

    }

    public class CarServiceAdapter : ICarServiceAdapter
    {

        private static readonly List<Car> cars = new List<Car>
        {
            new Car { ID = 1, Brand = "Toyota", Model = "Corolla", YearOfProduction = 2019, CarRegistration = "ABC123" },
            new Car { ID = 2, Brand = "Honda", Model = "Civic", YearOfProduction = 2020, CarRegistration = "XYZ789" }
        };

        private readonly ICarService _carService;

        public CarServiceAdapter(ICarService carService)
        {
            _carService = carService;
        }

         public List<CarDetails> GetAllCarDetails()
        {
            var carDtos = _carService.GetAllCarsAsync();
            return cars.Select(carDto => new CarDetails
            {
                ID = carDto.ID,
                Brand = carDto.Brand,
                Model = carDto.Model,
                YearOfProduction = carDto.YearOfProduction,
                CarRegistration = carDto.CarRegistration
            }).ToList();
        }
    }

    public class CarQuery : ObjectGraphType
    {
        public CarQuery(ICarServiceAdapter carServiceAdapter)
        {
            Field<ListGraphType<CarDetailsType>>(Name = "Cars", resolve: x => carServiceAdapter.GetAllCarDetails());
        }
    }

    public class CarDetailsSchema : Schema
    {
        public CarDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<CarQuery>();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();

            /*
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            builder.Services.AddSingleton<EmployeeDetailsType>();
            builder.Services.AddSingleton<EmployeeQuery>();
            builder.Services.AddSingleton<ISchema, EmployeeDetailsSchema>();
            */

            builder.Services.AddScoped<ICarServiceAdapter, CarServiceAdapter>();
            builder.Services.AddScoped<CarDetailsType>();
            builder.Services.AddScoped<CarQuery>();
            builder.Services.AddScoped<ISchema, CarDetailsSchema>();


            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddGraphQL(b => b
                //.AddAutoSchema<EmployeeQuery>()
                .AddAutoSchema<CarQuery>()
                .AddSystemTextJson()
            );

            // Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL("/graphql");
            app.UseGraphQLPlayground("/", new PlaygroundOptions
            {
                GraphQLEndPoint = "/graphql",
                SubscriptionsEndPoint = "/graphql",
            });

            app.MapControllers();

            app.Run();
        }
    }
}
