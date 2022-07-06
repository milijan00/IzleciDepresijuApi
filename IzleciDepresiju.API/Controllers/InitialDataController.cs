using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IzleciDepresiju.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private IzleciDepresijuDbContext _context;

        public InitialDataController(IzleciDepresijuDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post()
        {
            //if (this._context.Roles.Any())
            //{
            //    return Conflict();
            //}

            //var navigationLinks = new List<NavigationLink>
            //{
            //    new NavigationLink {Name = "Početna", Route="/", State=""},
            //    new NavigationLink {Name = "Pitanja", Route="/faq", State=""},
            //    new NavigationLink {Name = "O nama", Route="/aboutus", State=""},
            //    new NavigationLink {Name = "Prijava", Route="/login", State=""},
            //    new NavigationLink {Name = "Registracija", Route="/registration", State=""},
            //    new NavigationLink {Name = "Kontakt", Route="/contact", State=""},
            //    new NavigationLink {Name = "Zakazivanja", Route="/appointments", State=""}
            //};

            //var roles = new List<Role>
            //{
            //    new Role {Name = "Administrator"},
            //    new Role {Name = "Regular user"},
            //    new Role {Name = "Therapist"}
            //};

            //var symptoms = new List<DepressionSymptom>
            //{
            //    new DepressionSymptom {Name = "Emocionalni simptomi", Description="depresivno raspoloženje, osećaj gubitka radosti, osećanje bezosećajnosti, ravnodušnost, anksioznost, osećaj krivice, bezvrednosti, pesimizam"},
            //    new DepressionSymptom {Name = "Motivacioni simptomi", Description="kolebljivost volje (osoba ne može da donese odluku, da sprovede voljnu delatnost), psihomotorna usporenost, bezvoljnost, sniženje vitalnih dinamizama"},
            //    new DepressionSymptom {Name = "Kognitivni simptomi", Description="poremećaj koncentracije, usmerenost na sebe, zaboravnost do pseudodemencije (50%), usporenost govora, doživljaj praznine u mišljenju. Mišljenje karakteriše: samoomalovažavanje, osećaj nemoći, nesposobnosti, krivice, moralnog propadanja, siromaštva, ekonomske propasti, neizlečive bolesti"},
            //    new DepressionSymptom {Name = "Somatski simptomi", Description="glavobolja, bol u leđima, stezanje u grudima, abdominalni bol, vrtoglavice, palpitacije, iscrpljenost"},
            //};
            //var workdays = new List<Workday>
            //{
            //    new Workday{Name = "Ponedeljak"},
            //    new Workday{Name = "Utorak"},
            //    new Workday{Name = "Sreda"},
            //    new Workday{Name = "Četvrtak"},
            //    new Workday{Name = "Petak"}
            //};

            //var times = new List<Time>
            //{
            //};
            //foreach(var time in new string[] {"13:00", "14:00", "15:00", "16:00", "17:00" })
            //{
            //    times.Add(new Time() { Value = time });
            //}

            //var users = new List<User>
            //{
            //    new User( ){
            //        FirstName="Veljko",
            //        LastName = "Biberče",
            //        Image = "veljkoBiberce.jpg",
            //        Email = "veljko.biberce@gmail.com",
            //        Phone = "+381 64 145 6679",
            //        Username = "Veljko123",
            //        Password = BCrypt.Net.BCrypt.HashPassword("Pass123"),
            //        Role = roles.ElementAt(2)
            //    },
            //    new User( ){
            //        FirstName="Valentina",
            //        LastName = "Aleksić",
            //        Image = "valentinaAleksic.jpg",
            //        Email = "valetina.aleksic@gmail.com",
            //        Phone = "+381 64 267 8890",
            //        Username = "Valentina123",
            //        Password = BCrypt.Net.BCrypt.HashPassword("Pass123"),
            //        Role = roles.ElementAt(2)
            //    },
            //    new User( ){
            //        FirstName="Marina",
            //        LastName = "Petrović",
            //        Image = "marinaPetrovic.jpg",
            //        Email = "marina.petrovic@gmail.com",
            //        Phone = "+381 64 361 6636",
            //        Username = "Marina123",
            //        Password = BCrypt.Net.BCrypt.HashPassword("Pass123"),
            //        Role = roles.ElementAt(2)
            //    },
            //    new User( ){
            //        FirstName="Srećko",
            //        LastName = "Mrgud",
            //        Image = "sreckoPeric.jpg",
            //        Email = "srecko.mrgud@gmail.com",
            //        Phone = "+381 64 421 1224",
            //        Username = "Srecko123",
            //        Password = BCrypt.Net.BCrypt.HashPassword("Pass123"),
            //        Role = roles.ElementAt(2)
            //    },
            //    new User( ){
            //        FirstName="Ivana",
            //        LastName = "Spasojević",
            //        Image = "ivanaSpasojevic.jpg",
            //        Email = "ivana.spasojevic@gmail.com",
            //        Phone = "+381 64 456 7656",
            //        Username = "Ivana123",
            //        Password = BCrypt.Net.BCrypt.HashPassword("Pass123"),
            //        Role = roles.ElementAt(2)
            //    }, 
            //    new User( ){
            //        FirstName="Aleksandar",
            //        LastName = "Milijanović",
            //        Image = "autor.jpg",
            //        Email = "aleksandar.milijanovic.91.19@ict.edu.rs",
            //        Phone = "+381 65 558 9808",
            //        Username = "Milijan00",
            //        Password = BCrypt.Net.BCrypt.HashPassword("Milijan00"),
            //        Role = roles.ElementAt(2)
            //    }
            //};

            //this._context.NavigationLinks.AddRange(navigationLinks);
            //this._context.Roles.AddRange(roles);
            //this._context.DepressionSymptoms.AddRange(symptoms);
            //this._context.Workdays.AddRange(workdays);
            //this._context.Times.AddRange(times);
            //this._context.Users.AddRange(users);
            //this._context.SaveChanges();
            // unesi raspored za svakog teraputa
            var times = this._context.Times.ToList();
            var therapist = this._context.Users.Where(u => u.RoleId == 3).ToList();
            var workdays = this._context.Workdays.ToList();
            var availableAppointments = new List<AvailableAppointment>()
            {
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=1,
                    TimeToId = 2,
                    WorkdayId = 1
                    
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=1,
                    TimeToId = 3,
                    WorkdayId = 1
                    
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=2,
                    TimeToId = 3,
                    WorkdayId = 1
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=1,
                    TimeToId = 2,
                    WorkdayId = 5
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=1,
                    TimeToId = 3,
                    WorkdayId = 5
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=1,
                    TimeToId = 4,
                    WorkdayId = 5
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=2,
                    TimeToId = 3,
                    WorkdayId = 5
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=2,
                    TimeToId = 4,
                    WorkdayId = 5
                },
                new AvailableAppointment
                {
                    TherapistId = 1,
                    TimeFromId=3,
                    TimeToId = 4,
                    WorkdayId = 5
                },
                new AvailableAppointment
                {
                    TherapistId = 4,
                    TimeFromId=3,
                    TimeToId = 4,
                    WorkdayId = 2
                },
                new AvailableAppointment
                {
                    TherapistId = 4,
                    TimeFromId=3,
                    TimeToId = 5,
                    WorkdayId = 2
                },
                new AvailableAppointment
                {
                    TherapistId = 4,
                    TimeFromId=4,
                    TimeToId = 5,
                    WorkdayId = 2
                },
                new AvailableAppointment
                {
                    TherapistId = 3,
                    TimeFromId=1,
                    TimeToId = 2,
                    WorkdayId = 4
                },
                new AvailableAppointment
                {
                    TherapistId = 3,
                    TimeFromId=1,
                    TimeToId = 3,
                    WorkdayId = 4
                },
                new AvailableAppointment
                {
                    TherapistId = 3,
                    TimeFromId=2,
                    TimeToId = 3,
                    WorkdayId = 4
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=1,
                    TimeToId = 2,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=1,
                    TimeToId = 3,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=1,
                    TimeToId = 4,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=1,
                    TimeToId = 5,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=2,
                    TimeToId = 3,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=2,
                    TimeToId = 4,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=2,
                    TimeToId = 5,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=3,
                    TimeToId = 4,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=3,
                    TimeToId = 5,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 2,
                    TimeFromId=4,
                    TimeToId = 5,
                    WorkdayId = 3
                },
                new AvailableAppointment
                {
                    TherapistId = 5,
                    TimeFromId=4,
                    TimeToId = 5,
                    WorkdayId = 4
                },
                new AvailableAppointment
                {
                    TherapistId = 5,
                    TimeFromId=4,
                    TimeToId = 5,
                    WorkdayId = 5
                },

            };
            this._context.AvailableAppointments.AddRange(availableAppointments);
            this._context.SaveChanges();

            return StatusCode(201);
        }
    }
}
