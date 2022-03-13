using Microsoft.EntityFrameworkCore;
using NETCoreEFCoreRelationships.DAO;
using NETCoreEFCoreRelationships.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NETCoreEFCoreRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext context = new DataContext())
            {
                context.Database.Migrate();
            }

            //using (DataContext context = new DataContext())
            //{
            //    AddNewFederation(context);
            //}

            //using (DataContext context = new DataContext())
            //{
            //    UpdateFederation(context);
            //}

            //using (DataContext context = new DataContext())
            //{
            //    AddFederationChildren(context);
            //}

            //using (DataContext context = new DataContext())
            //{
            //    AddNewChampionshipToFederation(context);
            //}

            //using (DataContext context = new DataContext())
            //{
            //    RemoveChampionshipFromFederation(context);
            //}

            using (DataContext context = new DataContext())
            {
                ChangeChampionshipFromFederation(context);
            }


            Console.WriteLine("Hello World!");
        }

        private static void ChangeChampionshipFromFederation(DataContext context)
        {
            Championship champ = new Championship()
            {
                ID = 1,
                FederationID = 1                
            };

            context.Championships.Attach(champ);
            context.Entry(champ).State = EntityState.Modified;
            context.SaveChanges();
        }

        private static void RemoveChampionshipFromFederation(DataContext context)
        {
            Federation fed = new Federation()
            {
                ID = 1,
                Name = "CBF Sem Paulistão",
                LstChampionship = new List<Championship>() {
                    new Championship()
                    {
                        ID = 1,
                        Name = "Campeonato Brasileiro"
                    },
                },
            };

            Federation federationFromDb = context.Federations
                .Where(x => x.ID == 1)
                .Include(x => x.LstChampionship)
                .SingleOrDefault();

            context.Entry(federationFromDb).CurrentValues.SetValues(fed);
            federationFromDb.LstChampionship = fed.LstChampionship;

            context.SaveChanges();
        }

        private static void AddNewChampionshipToFederation(DataContext context)
        {
            Federation fed = new Federation()
            {
                ID = 1,
                LstChampionship = new List<Championship>(){
                    new Championship()
                    {
                        Name = "Campeonato Paulista",
                        DivisionList = new List<Division>()
                        {
                            new Division()
                            {
                                Name = "Série A",
                                LstTeam = new List<Team>()
                                {
                                    new Team()
                                    {
                                        Name = "São Paulo Futebol Clube"
                                    },
                                    new Team()
                                    {
                                        Name = "Santos Futebol Clube"
                                    }
                                }
                            }
                        }

                    }
                }
            };

            context.Federations.Attach(fed);
            context.Entry(fed).State = EntityState.Modified;
            context.SaveChanges();
        }

        private static void AddFederationChildren(DataContext context)
        {
            Federation fed = new Federation()
            {
                ID = 1,
                LstChampionship = new List<Championship>(){
                    new Championship()
                    {
                        Name = "Campeonato Brasileiro",
                        DivisionList = new List<Division>()
                        {
                            new Division()
                            {
                                Name = "Série A",
                                LstTeam = new List<Team>()
                                {
                                    new Team()
                                    {
                                        Name = "Sport Clube Internacional"
                                    },
                                    new Team()
                                    {
                                        Name = "Grêmio Foot Ball Porto Alegrense"
                                    }
                                }
                            },
                            new Division()
                            {
                                Name = "Série B",
                                LstTeam = new List<Team>()
                                {
                                    new Team()
                                    {
                                        Name = "Brasil de Pelotas"
                                    },
                                    new Team()
                                    {
                                        Name = "Milonga"
                                    }
                                }
                            }
                        }
                    },                   
                }
            };

            context.Federations.Attach(fed);
            context.Entry(fed).State = EntityState.Modified;
            context.SaveChanges();
        }

        private static void UpdateFederation(DataContext context)
        {
            Federation fed = new Federation()
            {
                ID = 1,
                Name = "Confederação Brasileira de Futebol (CBF)"
            };

            context.Federations.Attach(fed);
            context.Entry(fed).State = EntityState.Modified;
            context.SaveChanges();
        }

        private static void AddNewFederation(DataContext context)
        {
            Federation fed = new Federation()
            {
                Name = "UEFA"
            };

            context.Federations.Add(fed);
            context.SaveChanges();
        }
    }
}
