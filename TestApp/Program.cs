using DAL;
using Entities;
using System;
using System.Collections.Generic;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ContactBookUOW uow = new ContactBookUOW(new ContactBookContext()))
            {
                //Add
                Person p = new Person();
                p.Name = "Luiz";
                p.Contacts.Add(new Contact { Type = ContactType.Celphone, Value = "00000000" });
                p.Contacts.Add(new Contact { Type = ContactType.ResidentialPhone, Value = "00000000" });

                p.Addresses.Add(new Address { Type = AddressType.Residential, StreetName = "Rua Eduardo Bezerra" });
                p.Addresses.Add(new Address { Type = AddressType.Comercial, StreetName = "Rua Monsenhor Salazar" });

                uow.Persons.Add(p);
                uow.SaveChanges();

                //Show
                List<Marker> markers = new List<Marker>(uow.Markers.GetAll());
                markers.Add(null);

                foreach (var marker in markers)
                {
                    if (marker != null)
                    {
                        Console.WriteLine("*** " + marker.Description + " ***");
                    }
                    else
                    {
                        Console.WriteLine("*** Outros ***");
                    }

                    List<Person> persons = new List<Person>(uow.Persons.GetByMarker(marker));

                    foreach (var person in persons)
                    {
                        Console.WriteLine(person.Name);

                        foreach (Address item in person.Addresses)
                        {
                            Console.WriteLine(item.StreetName + ", " + item.Number);
                        }

                        foreach (Contact item in person.Contacts)
                        {
                            Console.WriteLine(item.Type.ToString() + ": " + item.Value);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Programa finalizado!");
            Console.Read();
        }
    }
}
